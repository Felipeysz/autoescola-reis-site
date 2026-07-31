using Microsoft.AspNetCore.Mvc;
using AutoescolaReisSite.Models;
using AutoescolaReisSite.Services;

namespace AutoescolaReisSite.Controllers
{
    public class MatriculasController : Controller
    {
        private readonly ICrmClient _crmClient;

        public MatriculasController(ICrmClient crmClient)
        {
            _crmClient = crmClient;
        }

        [Route("matriculas")]
        [HttpGet]
        public IActionResult Index() => View(new MatriculaForm());

        [Route("matriculas")]
        [HttpPost]
        public async Task<IActionResult> Index(MatriculaForm form)
        {
            if (!ModelState.IsValid)
            {
                return View(form);
            }

            var lead = new CrmLeadRequest
            {
                Nome = form.Nome,
                Telefone = form.Telefone,
                Email = form.Email,
                ServicoDesejado = form.Servico,
                Origem = "Site"
            };

            await _crmClient.EnviarLeadAsync(lead);

            // Mesmo se o CRM falhar, o usuário sempre vê sucesso (LASDWAS-53)
            TempData["MatriculaEnviada"] = true;
            return RedirectToAction("Index");
        }
    }
}