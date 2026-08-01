// Controllers/Api/WhatsAppController.cs
using AutoescolaReisSite.Crm.Dtos;
using AutoescolaReisSite.Crm.Services;
using Microsoft.AspNetCore.Mvc;

namespace AutoescolaReisSite.Crm.Controllers.Api
{
    [ApiController]
    [Route("api/whatsapp")]
    public class WhatsAppController : ControllerBase
    {
        private readonly IAtendimentoBot _bot;
        private readonly ILogger<WhatsAppController> _logger;

        public WhatsAppController(IAtendimentoBot bot, ILogger<WhatsAppController> logger)
        {
            _bot = bot;
            _logger = logger;
        }

        // Simula o webhook que a Meta Cloud API / Twilio vai chamar de verdade
        // quando a API oficial do WhatsApp for aprovada (troca só a "porta de entrada").
        [HttpPost("mock-mensagem")]
        public async Task<IActionResult> ReceberMensagemMock([FromBody] MensagemWhatsAppRequest request)
        {
            if (!ModelState.IsValid)
            {
                return ValidationProblem(ModelState);
            }

            _logger.LogInformation("Mensagem recebida (mock) de {Telefone}: {Texto}", request.Telefone, request.Texto);

            var resposta = await _bot.ResponderAsync(request.Telefone, request.Texto);

            return Ok(new { telefone = request.Telefone, resposta });
        }
    }
}