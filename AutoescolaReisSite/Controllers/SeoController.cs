// Controllers/SeoController.cs
using System.Text;
using AutoescolaReisSite.Data;
using Microsoft.AspNetCore.Mvc;

namespace AutoescolaReisSite.Controllers
{
    public class SeoController : Controller
    {
        // Rotas estáticas do site (fora de Cursos e Notícias, que são geradas dinamicamente a partir dos Data/*.cs)
        private static readonly (string Path, string ChangeFreq, string Priority)[] RotasEstaticas =
        {
            ("/",                          "weekly",  "1.0"),
            ("nossos-cursos",               "monthly", "0.8"),
            ("sobre-nos",                   "monthly", "0.5"),
            ("matriculas",                  "monthly", "0.8"),
            ("noticias",                    "weekly",  "0.6"),
            ("perguntas-frequentes",        "monthly", "0.5"),
            ("politica-privacidade",        "yearly",  "0.2"),
        };

        [Route("sitemap.xml")]
        public IActionResult Sitemap()
        {
            var baseUrl = $"{Request.Scheme}://{Request.Host}";

            var sb = new StringBuilder();
            sb.AppendLine("<?xml version=\"1.0\" encoding=\"UTF-8\"?>");
            sb.AppendLine("<urlset xmlns=\"http://www.sitemaps.org/schemas/sitemap/0.9\">");

            foreach (var rota in RotasEstaticas)
            {
                var loc = rota.Path == "/" ? $"{baseUrl}/" : $"{baseUrl}/{rota.Path}";
                AppendUrl(sb, loc, rota.ChangeFreq, rota.Priority);
            }

            // Páginas de cursos — geradas a partir de CursosData, sem precisar duplicar rotas aqui
            foreach (var curso in CursosData.Todos)
            {
                AppendUrl(sb, $"{baseUrl}/{curso.Slug}", "monthly", "0.7");
            }

            // Notícias — geradas a partir de NoticiasData
            foreach (var post in NoticiasData.Todas)
            {
                AppendUrl(sb, $"{baseUrl}/post/{post.Slug}", "yearly", "0.4");
            }

            sb.AppendLine("</urlset>");

            return Content(sb.ToString(), "application/xml", Encoding.UTF8);
        }

        [Route("robots.txt")]
        public IActionResult Robots()
        {
            var baseUrl = $"{Request.Scheme}://{Request.Host}";

            var sb = new StringBuilder();
            sb.AppendLine("User-agent: *");
            sb.AppendLine("Allow: /");
            sb.AppendLine();
            sb.AppendLine($"Sitemap: {baseUrl}/sitemap.xml");

            return Content(sb.ToString(), "text/plain", Encoding.UTF8);
        }

        private static void AppendUrl(StringBuilder sb, string loc, string changeFreq, string priority)
        {
            sb.AppendLine("  <url>");
            sb.AppendLine($"    <loc>{loc}</loc>");
            sb.AppendLine($"    <changefreq>{changeFreq}</changefreq>");
            sb.AppendLine($"    <priority>{priority}</priority>");
            sb.AppendLine("  </url>");
        }
    }
}