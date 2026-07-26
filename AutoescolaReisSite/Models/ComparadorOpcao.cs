// Models/ComparadorOpcao.cs
namespace AutoescolaReisSite.Models
{
    public class ComparadorOpcao
    {
        public string Pergunta { get; set; } = "";   // "Quero pilotar moto"
        public string Slug { get; set; } = "";        // link pro curso
        public string CodigoCurso { get; set; } = "";  // "A" — reaproveita o badge visual
    }
}