// Controllers/MatriculasController.cs
using Microsoft.AspNetCore.Mvc;
using AutoescolaReisSite.Models;

namespace AutoescolaReisSite.Controllers
{
    public class MatriculasController : Controller
    {
        [Route("matriculas")]
        [HttpGet]
        public IActionResult Index() => View(new MatriculaForm());

        [Route("matriculas")]
        [HttpPost]
        public IActionResult Index(MatriculaForm form)
        {
            if (!ModelState.IsValid)
            {
                return View(form);
            }

            // TODO: v1 não tem backend de envio ainda.
            // Opções pra próxima sprint: enviar por email (SMTP) ou salvar em banco.
            // Por enquanto, só confirma recebimento pro usuário.

            TempData["MatriculaEnviada"] = true;
            return RedirectToAction("Index");
        }
    }
}