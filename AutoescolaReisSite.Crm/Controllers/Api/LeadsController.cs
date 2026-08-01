// Controllers/Api/LeadsController.cs
using AutoescolaReisSite.Crm.Data;
using AutoescolaReisSite.Crm.Dtos;
using AutoescolaReisSite.Crm.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AutoescolaReisSite.Crm.Controllers.Api
{
    [ApiController]
    [Route("api/leads")]
    public class LeadsController : ControllerBase
    {
        private readonly CrmDbContext _db;

        public LeadsController(CrmDbContext db)
        {
            _db = db;
        }

        [HttpPost]
        public async Task<IActionResult> Criar([FromBody] CriarLeadRequest request)
        {
            if (!ModelState.IsValid)
            {
                return ValidationProblem(ModelState);
            }

            if (!Enum.TryParse<OrigemLead>(request.Origem, ignoreCase: true, out var origem))
            {
                origem = OrigemLead.Site;
            }

            var telefoneNormalizado = NormalizarTelefone(request.Telefone);

            var leadExistente = await _db.Leads
                .FirstOrDefaultAsync(l => l.Telefone == telefoneNormalizado);

            if (leadExistente is not null)
            {
                // Atualiza o registro existente em vez de criar um novo
                leadExistente.Nome = request.Nome;
                leadExistente.Email = request.Email;
                leadExistente.ServicoDesejado = request.ServicoDesejado;
                leadExistente.DataUltimaInteracao = DateTime.UtcNow;
                // Não sobrescreve Status nem Origem — mantém o estágio do pipeline
                // em que o lead já estava (ex: não volta um lead "Em contato" pra "Novo")

                await _db.SaveChangesAsync();

                return Ok(leadExistente);
            }

            var lead = new Lead
            {
                Nome = request.Nome,
                Telefone = telefoneNormalizado,
                Email = request.Email,
                ServicoDesejado = request.ServicoDesejado,
                Origem = origem,
                Status = PipelineStage.Novo,
                DataCriacao = DateTime.UtcNow,
                DataUltimaInteracao = DateTime.UtcNow
            };

            _db.Leads.Add(lead);
            await _db.SaveChangesAsync();

            return CreatedAtAction(nameof(ObterPorId), new { id = lead.Id }, lead);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> ObterPorId(int id)
        {
            var lead = await _db.Leads.FindAsync(id);
            return lead is null ? NotFound() : Ok(lead);
        }

        private static string NormalizarTelefone(string telefone)
        {
            // Remove tudo que não for dígito
            var digitos = new string(telefone.Where(char.IsDigit).ToArray());

            // Garante formato E.164 (+55...) — ajuste conforme os dados que já existem no banco
            if (!digitos.StartsWith("55"))
            {
                digitos = "55" + digitos;
            }

            return "+" + digitos;
        }
    }
}