// Models/CursoInfo.cs
namespace AutoescolaReisSite.Models
{
    public class CursoInfo
    {
        public string? Codigo { get; set; }
        public string Slug { get; set; } = "";
        public string Titulo { get; set; } = "";
        public string Subtitulo { get; set; } = "";
        public string TextoIntroducao { get; set; } = "";
        public string? CategoriaNome { get; set; }
        public string? CategoriaDescricao { get; set; }
        public string? Importante { get; set; }
        public List<string>? Etapas { get; set; }
        // Usado só na "Adição de Categoria", que tem etapas separadas por A e B
        public Dictionary<string, List<string>>? EtapasPorGrupo { get; set; }
        public List<string>? Exigencias { get; set; }
        public string? ImagemUrl { get; set; } // RESERVADO — preencher depois
    }
}