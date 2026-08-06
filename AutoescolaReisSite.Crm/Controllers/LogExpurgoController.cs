using AutoescolaReisSite.Crm.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AutoescolaReisSite.Crm.Controllers
{
    [Authorize]
    public class LogExpurgoController : Controller
    {
        private readonly CrmDbContext _db;

        public LogExpurgoController(CrmDbContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> Index()
        {
            var logs = await _db.LeadExpurgoLogs
                .OrderByDescending(l => l.ExcluidoEm)
                .ToListAsync();

            return View(logs);
        }
    }
}