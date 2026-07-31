// Controllers/HealthController.cs
using Microsoft.AspNetCore.Mvc;

namespace AutoescolaReisSite.Crm.Controllers
{
    [ApiController]
    [Route("health")]
    public class HealthController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new { status = "ok", servico = "AutoescolaReisSite.Crm" });
        }
    }
}