// Controllers/HomeController.cs
using System.Diagnostics;
using AutoescolaReisSite.Models;
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

        [Route("erro/{statusCode?}")]
        public IActionResult Error(int? statusCode)
        {
            var model = new ErrorViewModel
            {
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier,
                StatusCode = statusCode ?? 500
            };

            Response.StatusCode = model.StatusCode;
            return View(model);
        }
    }
}