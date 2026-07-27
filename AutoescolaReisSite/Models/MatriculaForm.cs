// Models/MatriculaForm.cs
using System.ComponentModel.DataAnnotations;

namespace AutoescolaReisSite.Models
{
    public class MatriculaForm
    {
        [Required(ErrorMessage = "Informe seu nome.")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Informe seu nome completo (mínimo 3 letras).")]
        public string Nome { get; set; } = "";

        [Required(ErrorMessage = "Informe um telefone/WhatsApp para contato.")]
        [RegularExpression(@"^\(?\d{2}\)?\s?9?\d{4}-?\d{4}$", ErrorMessage = "Informe um telefone válido, com DDD (ex: (71) 98260-0856).")]
        public string Telefone { get; set; } = "";

        [Required(ErrorMessage = "Informe seu email.")]
        [EmailAddress(ErrorMessage = "Email inválido.")]
        public string Email { get; set; } = "";

        [Required(ErrorMessage = "Selecione um serviço.")]
        public string Servico { get; set; } = "";

        public static readonly List<string> Servicos = new()
        {
            "1º Habilitação Categoria “A”",
            "1º Habilitação Categoria “B”",
            "1ª Habilitação Categoria “A” e “B”",
            "Adição de Categoria",
            "Mudança para Categoria “D”",
            "Mudança para Categoria “E”",
            "Curso de Reciclagem"
        };
    }
}