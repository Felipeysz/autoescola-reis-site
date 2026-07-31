using System.ComponentModel.DataAnnotations;

namespace AutoescolaReisSite.Crm.Models
{
    public class Usuario
    {
        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string Nome { get; set; } = "";

        [Required, MaxLength(150)]
        public string Email { get; set; } = "";

        [Required]
        public string SenhaHash { get; set; } = "";
    }
}