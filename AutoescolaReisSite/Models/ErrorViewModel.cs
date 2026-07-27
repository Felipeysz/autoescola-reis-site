namespace AutoescolaReisSite.Models;

public class ErrorViewModel
{
    public string? RequestId { get; set; }
    public int StatusCode { get; set; } = 500;

    public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);

    public string Titulo => StatusCode switch
    {
        404 => "Página não encontrada",
        _ => "Ops, algo deu errado"
    };

    public string Mensagem => StatusCode switch
    {
        404 => "A página que você tentou acessar não existe ou foi movida. Confira o endereço ou volte para o início.",
        _ => "Nossa equipe já foi avisada. Tente novamente em alguns minutos ou fale com a gente pelo WhatsApp."
    };
}