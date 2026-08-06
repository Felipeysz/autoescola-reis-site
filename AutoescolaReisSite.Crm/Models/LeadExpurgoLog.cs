namespace AutoescolaReisSite.Crm.Models
{
    public class LeadExpurgoLog
    {
        public int Id { get; set; }

        // Guardamos só o suficiente pra auditoria — nunca o dado pessoal completo
        public int LeadIdOriginal { get; set; }
        public string TelefoneParcial { get; set; } = "";
        public PipelineStage StatusNoMomento { get; set; }
        public DateTime DataUltimaInteracaoNoMomento { get; set; }
        public DateTime ExcluidoEm { get; set; } = DateTime.UtcNow;
        public string Motivo { get; set; } = "Retenção automática — LGPD";
    }
}