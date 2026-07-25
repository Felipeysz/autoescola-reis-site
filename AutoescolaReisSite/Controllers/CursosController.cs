// Controllers/CursosController.cs
using Microsoft.AspNetCore.Mvc;
using AutoescolaReisSite.Models;
using AutoescolaReisSite.Data;

namespace AutoescolaReisSite.Controllers
{
    public class CursosController : Controller
    {
        [Route("nossos-cursos")]
        public IActionResult Index() => View();

        [Route("cnh-categoria-a")]
        public IActionResult CategoriaA() => View("Detalhe", CursosData.CategoriaA);

        [Route("cnh-categoria-b")]
        public IActionResult CategoriaB() => View("Detalhe", CursosData.CategoriaB);

        [Route("cnh-categoria-ab")]
        public IActionResult CategoriaAB() => View("Detalhe", CursosData.CategoriaAB);

        [Route("cnh-categoria-d")]
        public IActionResult CategoriaD() => View("Detalhe", CursosData.CategoriaD);

        [Route("cnh-categoria-e")]
        public IActionResult CategoriaE() => View("Detalhe", CursosData.CategoriaE);

        [Route("adicao-categoria")]
        public IActionResult AdicaoCategoria() => View("Detalhe", CursosData.AdicaoCategoria);

        [Route("curso-reciclagem")]
        public IActionResult Reciclagem() => View("Detalhe", CursosData.Reciclagem);
    }
}