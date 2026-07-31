using AutoescolaReisSite.Models;

namespace AutoescolaReisSite.Services
{
    public interface ICrmClient
    {
        Task<bool> EnviarLeadAsync(CrmLeadRequest lead);
    }
}