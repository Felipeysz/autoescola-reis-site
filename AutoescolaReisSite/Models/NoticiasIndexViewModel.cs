// Models/NoticiasIndexViewModel.cs
namespace AutoescolaReisSite.Models
{
    public class NoticiasIndexViewModel
    {
        public List<NoticiaPost> Posts { get; set; } = new();
        public int PaginaAtual { get; set; } = 1;
        public int TotalPaginas { get; set; } = 1;

        public bool TemPaginaAnterior => PaginaAtual > 1;
        public bool TemProximaPagina => PaginaAtual < TotalPaginas;
    }
}