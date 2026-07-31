namespace AutoescolaReisSite.Models
{
    public class CrmLeadRequest
    {
        public string Nome { get; set; } = "";
        public string Telefone { get; set; } = "";
        public string? Email { get; set; }
        public string ServicoDesejado { get; set; } = "";
        public string Origem { get; set; } = "Site";
    }
}