using System.Net.Http.Json;
using AutoescolaReisSite.Models;

namespace AutoescolaReisSite.Services
{
    public class CrmClient : ICrmClient
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILogger<CrmClient> _logger;

        public CrmClient(IHttpClientFactory httpClientFactory, ILogger<CrmClient> logger)
        {
            _httpClientFactory = httpClientFactory;
            _logger = logger;
        }

        public async Task<bool> EnviarLeadAsync(CrmLeadRequest lead)
        {
            try
            {
                var client = _httpClientFactory.CreateClient("CrmApi");
                var response = await client.PostAsJsonAsync("api/leads", lead);

                if (!response.IsSuccessStatusCode)
                {
                    _logger.LogWarning(
                        "CRM retornou {StatusCode} ao enviar lead de {Nome}",
                        response.StatusCode, lead.Nome);
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                // CRM fora do ar não pode quebrar o formulário do site (LASDWAS-53)
                _logger.LogError(ex, "Falha ao enviar lead pro CRM: {Nome}", lead.Nome);
                return false;
            }
        }
    }
}