// Controllers/LeadsController.cs
using AutoescolaReisSite.Crm.Data;
using AutoescolaReisSite.Crm.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AutoescolaReisSite.Crm.Controllers
{
    [Authorize]
    public class LeadsController : Controller
    {
        private readonly CrmDbContext _db;

        public LeadsController(CrmDbContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> Index(PipelineStage? status)
        {
            var todos = await _db.Leads.ToListAsync();

            var leads = status.HasValue
                ? todos.Where(l => l.Status == status.Value).ToList()
                : todos;

            leads = leads.OrderByDescending(l => l.DataCriacao).ToList();

            ViewData["FiltroAtual"] = status;
            ViewData["Total"] = todos.Count;
            ViewData["Contagens"] = todos.GroupBy(l => l.Status).ToDictionary(g => g.Key, g => g.Count());

            return View(leads);
        }

        [HttpPost]
        public async Task<IActionResult> AtualizarStatus(int id, PipelineStage novoStatus)
        {
            var lead = await _db.Leads.FindAsync(id);

            if (lead is null)
            {
                return NotFound();
            }

            lead.Status = novoStatus;
            lead.DataUltimaInteracao = DateTime.UtcNow;
            await _db.SaveChangesAsync();

            return RedirectToAction("Index");
        }
    }
}