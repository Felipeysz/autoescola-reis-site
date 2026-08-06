using AutoescolaReisSite.Crm.Data;
using AutoescolaReisSite.Crm.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AutoescolaReisSite.Crm.Controllers
{
    [Authorize]
    public class ConfiguracaoController : Controller
    {
        private readonly CrmDbContext _db;

        public ConfiguracaoController(CrmDbContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> Retencao()
        {
            var config = await ObterOuCriarConfig();
            return View(config);
        }

        [HttpPost]
        public async Task<IActionResult> Retencao(int prazoDiasLeadPerdido)
        {
            if (prazoDiasLeadPerdido < 1 || prazoDiasLeadPerdido > 3650)
            {
                ModelState.AddModelError(nameof(prazoDiasLeadPerdido), "Informe um valor entre 1 e 3650 dias.");
                var configAtual = await ObterOuCriarConfig();
                return View(configAtual);
            }

            var config = await ObterOuCriarConfig();
            config.PrazoDiasLeadPerdido = prazoDiasLeadPerdido;
            config.AtualizadoEm = DateTime.UtcNow;
            await _db.SaveChangesAsync();

            TempData["Mensagem"] = "Prazo de retenção atualizado.";
            return RedirectToAction(nameof(Retencao));
        }

        private async Task<ConfiguracaoRetencao> ObterOuCriarConfig()
        {
            var config = await _db.ConfiguracoesRetencao.FirstOrDefaultAsync();

            if (config is null)
            {
                config = new ConfiguracaoRetencao();
                _db.ConfiguracoesRetencao.Add(config);
                await _db.SaveChangesAsync();
            }

            return config;
        }
    }
}