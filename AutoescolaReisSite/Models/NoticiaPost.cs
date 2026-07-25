// Models/NoticiaPost.cs
namespace AutoescolaReisSite.Models
{
    public class NoticiaPost
    {
        public string Slug { get; set; } = "";
        public string Titulo { get; set; } = "";
        public string ResumoCurta { get; set; } = "";
        public string ConteudoHtml { get; set; } = "";
        public DateTime DataPublicacao { get; set; }
        public string? ImagemUrl { get; set; }   // RESERVADO — você adiciona a imagem depois
    }
}