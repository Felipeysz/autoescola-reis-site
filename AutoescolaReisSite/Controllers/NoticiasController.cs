// Controllers/NoticiasController.cs
using AutoescolaReisSite.Data;
using AutoescolaReisSite.Models;
using Microsoft.AspNetCore.Mvc;

namespace AutoescolaReisSite.Controllers
{
    public class NoticiasController : Controller
    {
        private const int TamanhoPagina = 6;

        [Route("noticias")]
        [Route("noticias/pagina/{pagina:int}")]
        public IActionResult Index(int pagina = 1)
        {
            var todasOrdenadas = NoticiasData.Todas
                .OrderByDescending(p => p.DataPublicacao)
                .ToList();

            var totalPaginas = Math.Max(1, (int)Math.Ceiling(todasOrdenadas.Count / (double)TamanhoPagina));
            var paginaAtual = Math.Clamp(pagina, 1, totalPaginas);

            var model = new NoticiasIndexViewModel
            {
                Posts = todasOrdenadas
                    .Skip((paginaAtual - 1) * TamanhoPagina)
                    .Take(TamanhoPagina)
                    .ToList(),
                PaginaAtual = paginaAtual,
                TotalPaginas = totalPaginas
            };

            return View(model);
        }

        [Route("post/{slug}")]
        public IActionResult Detalhes(string slug)
        {
            var post = NoticiasData.Todas.FirstOrDefault(p => p.Slug == slug);
            if (post == null) return NotFound();
            return View(post);
        }
    }
}