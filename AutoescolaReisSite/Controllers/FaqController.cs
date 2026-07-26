// Controllers/FaqController.cs
using Microsoft.AspNetCore.Mvc;
using AutoescolaReisSite.Data;

namespace AutoescolaReisSite.Controllers
{
    public class FaqController : Controller
    {
        [Route("perguntas-frequentes")]
        public IActionResult Index() => View(FaqData.Todas);
    }
}