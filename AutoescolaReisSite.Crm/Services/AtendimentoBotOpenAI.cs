// Services/AtendimentoBotOpenAI.cs
using System.Text.Json;
using AutoescolaReisSite.Crm.Dtos;

namespace AutoescolaReisSite.Crm.Services
{
    public class AtendimentoBotOpenAI : IAtendimentoBot
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILogger<AtendimentoBotOpenAI> _logger;

        // Prompt base com o contexto do negócio — a IA só sabe o que estiver aqui.
        // Se o cliente mudar preço/curso/horário, é AQUI que precisa atualizar.
        private const string PromptSistema = """
            Você é o atendente virtual da Autoescola Reis, em Salvador - BA.
            Responda de forma curta, direta e cordial, como se fosse WhatsApp (poucas linhas, sem formalidade excessiva).

            Informações do negócio:
            - Cursos oferecidos: 1ª Habilitação Categoria A (moto), Categoria B (carro), Categoria A e B juntas,
              Adição de Categoria, Mudança para Categoria D, Mudança para Categoria E, Curso de Reciclagem.
            - Aulas teóricas 100% online.
            - Facilitamos o pagamento (condições especiais, sob consulta).
            - Atendimento humano via WhatsApp para valores exatos e agendamento.

            Regras:
            - Nunca invente preço exato — diga que os valores variam e que um consultor humano confirma.
            - Se a pergunta fugir muito do assunto (autoescola/CNH), redirecione educadamente pro atendimento humano.
            - Nunca finja ser uma pessoa real — se perguntarem, admita que é um atendimento automático.
            """;

        public AtendimentoBotOpenAI(IHttpClientFactory httpClientFactory, ILogger<AtendimentoBotOpenAI> logger)
        {
            _httpClientFactory = httpClientFactory;
            _logger = logger;
        }

        public async Task<string> ResponderAsync(string telefone, string mensagemRecebida)
        {
            var client = _httpClientFactory.CreateClient("OpenAI");

            var request = new ChatCompletionRequest
            {
                Messages = new List<ChatMessage>
                {
                    new() { Role = "system", Content = PromptSistema },
                    new() { Role = "user", Content = mensagemRecebida }
                }
            };

            try
            {
                var response = await client.PostAsJsonAsync("chat/completions", request);

                if (!response.IsSuccessStatusCode)
                {
                    var corpo = await response.Content.ReadAsStringAsync();
                    _logger.LogWarning("OpenAI retornou {StatusCode}: {Corpo}", response.StatusCode, corpo);
                    return "Desculpa, tive um problema técnico agora. Um consultor humano vai te responder em breve.";
                }

                var resultado = await response.Content.ReadFromJsonAsync<ChatCompletionResponse>();
                var texto = resultado?.Choices.FirstOrDefault()?.Message.Content;

                return string.IsNullOrWhiteSpace(texto)
                    ? "Desculpa, não consegui entender. Pode reformular a pergunta?"
                    : texto.Trim();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Falha ao chamar OpenAI pro telefone {Telefone}", telefone);
                return "Desculpa, tive um problema técnico agora. Um consultor humano vai te responder em breve.";
            }
        }
    }
}