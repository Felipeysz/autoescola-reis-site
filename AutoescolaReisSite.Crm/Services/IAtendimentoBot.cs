namespace AutoescolaReisSite.Crm.Services
{
    public interface IAtendimentoBot
    {
        Task<string> ResponderAsync(string telefone, string mensagemRecebida);
    }
}