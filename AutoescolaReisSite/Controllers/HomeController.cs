// Controllers/HomeController.cs
using Microsoft.AspNetCore.Mvc;

namespace AutoescolaReisSite.Controllers
{
    public class HomeController : Controller
    {
        [Route("/")]
        public IActionResult Index() => View();

        [Route("sobre-nos")]
        public IActionResult Sobre() => View();

        [Route("politica-privacidade")]
        public IActionResult Politica() => View();
    }
}