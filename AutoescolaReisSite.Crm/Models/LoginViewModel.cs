using System.ComponentModel.DataAnnotations;

namespace AutoescolaReisSite.Crm.Models
{
    public class LoginViewModel
    {
        [Required, EmailAddress]
        public string Email { get; set; } = "";

        [Required, DataType(DataType.Password)]
        public string Senha { get; set; } = "";

        public string? ErroMensagem { get; set; }
    }
}