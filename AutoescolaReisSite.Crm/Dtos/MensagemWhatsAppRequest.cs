using System.ComponentModel.DataAnnotations;

namespace AutoescolaReisSite.Crm.Dtos
{
    public class MensagemWhatsAppRequest
    {
        [Required, MaxLength(20)]
        public string Telefone { get; set; } = "";

        [Required, MaxLength(2000)]
        public string Texto { get; set; } = "";
    }
}