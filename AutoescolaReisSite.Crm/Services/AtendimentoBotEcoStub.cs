namespace AutoescolaReisSite.Crm.Services
{
    // Implementação temporária (mock) — só devolve um eco da mensagem.
    // Será substituída pela integração real com OpenAI na LASDWAS-56,
    // sem precisar mudar nada no WhatsAppController.
    public class AtendimentoBotEcoStub : IAtendimentoBot
    {
        public Task<string> ResponderAsync(string telefone, string mensagemRecebida)
        {
            var resposta = $"[MOCK] Recebi sua mensagem: \"{mensagemRecebida}\". Em breve vou responder de verdade!";
            return Task.FromResult(resposta);
        }
    }
}