using System.ComponentModel.DataAnnotations;

namespace AutoescolaReisSite.Crm.Models
{
    public class Lead
    {
        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string Nome { get; set; } = "";

        [Required, MaxLength(20)]
        public string Telefone { get; set; } = "";

        [MaxLength(150)]
        public string? Email { get; set; }

        [Required, MaxLength(150)]
        public string ServicoDesejado { get; set; } = "";

        public OrigemLead Origem { get; set; } = OrigemLead.Site;

        public PipelineStage Status { get; set; } = PipelineStage.Novo;

        public DateTime DataCriacao { get; set; } = DateTime.UtcNow;
    }
}