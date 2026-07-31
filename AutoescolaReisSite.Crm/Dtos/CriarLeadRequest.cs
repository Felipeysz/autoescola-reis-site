// Dtos/CriarLeadRequest.cs
using System.ComponentModel.DataAnnotations;

namespace AutoescolaReisSite.Crm.Dtos
{
    public class CriarLeadRequest
    {
        [Required, MaxLength(100)]
        public string Nome { get; set; } = "";

        [Required, MaxLength(20)]
        public string Telefone { get; set; } = "";

        [MaxLength(150)]
        public string? Email { get; set; }

        [Required, MaxLength(150)]
        public string ServicoDesejado { get; set; } = "";

        public string Origem { get; set; } = "Site";
    }
}