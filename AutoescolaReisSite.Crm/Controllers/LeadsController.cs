// Controllers/LeadsController.cs
using AutoescolaReisSite.Crm.Data;
using AutoescolaReisSite.Crm.Dtos;
using AutoescolaReisSite.Crm.Models;
using Microsoft.AspNetCore.Mvc;

namespace AutoescolaReisSite.Crm.Controllers
{
    [ApiController]
    [Route("leads")]
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

            var lead = new Lead
            {
                Nome = request.Nome,
                Telefone = request.Telefone,
                Email = request.Email,
                ServicoDesejado = request.ServicoDesejado,
                Origem = origem,
                Status = PipelineStage.Novo,
                DataCriacao = DateTime.UtcNow
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
    }
}