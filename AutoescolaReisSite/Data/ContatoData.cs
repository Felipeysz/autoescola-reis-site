// Data/ContatoData.cs
namespace AutoescolaReisSite.Data
{
    public static class ContatoData
    {
        public const string EnderecoCompleto =
            "Avenida Tancredo Neves, 274, Torre A, Caminho das Árvores, Salvador - BA, 41820-620";

        public static string MapaEmbedUrl =>
            $"https://www.google.com/maps?q={Uri.EscapeDataString(EnderecoCompleto)}&output=embed";
    }
}