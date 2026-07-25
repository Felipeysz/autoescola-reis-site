// Controllers/NoticiasController.cs
using Microsoft.AspNetCore.Mvc;
using AutoescolaReisSite.Data;

namespace AutoescolaReisSite.Controllers
{
    public class NoticiasController : Controller
    {
        [Route("noticias")]
        public IActionResult Index() => View(NoticiasData.Todas);

        [Route("post/{slug}")]
        public IActionResult Detalhes(string slug)
        {
            var post = NoticiasData.Todas.FirstOrDefault(p => p.Slug == slug);
            if (post == null) return NotFound();
            return View(post);
        }
    }
}