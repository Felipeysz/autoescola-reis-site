using System.ComponentModel.DataAnnotations;

namespace AutoescolaReisSite.Crm.Models
{
    public class ConfiguracaoRetencao
    {
        public int Id { get; set; }

        [Range(1, 3650)]
        public int PrazoDiasLeadPerdido { get; set; } = 180;

        public DateTime AtualizadoEm { get; set; } = DateTime.UtcNow;
    }
}