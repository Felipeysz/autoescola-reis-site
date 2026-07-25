// Data/NoticiasData.cs
using AutoescolaReisSite.Models;

namespace AutoescolaReisSite.Data
{
    public static class NoticiasData
    {
        public static readonly List<NoticiaPost> Todas = new()
        {
            new NoticiaPost
            {
                Slug = "cnh-digital-veja-como-acessar-pelo-celular",
                Titulo = "CNH Digital: Veja como acessar pelo celular",
                ResumoCurta = "Portar a Carteira Nacional de Habilitação ficou ainda mais prático, já que por meio do site e aplicativo disponibilizados pelo governo é possível ter acesso à versão digital do documento.",
                ConteudoHtml = "<!-- TODO: colar o conteúdo completo do post original -->",
                DataPublicacao = new DateTime(2022, 8, 21),
                ImagemUrl = null
            },
            new NoticiaPost
            {
                Slug = "veja-como-renovar-consultar-pontos-e-tirar-2-via-da-cnh-digital",
                Titulo = "Veja como renovar, consultar pontos e tirar 2ª via da CNH digital",
                ResumoCurta = "A Carteira Nacional de Habilitação (CNH) é o documento que autoriza a condução de veículos automotores em todo o território nacional.",
                ConteudoHtml = "<!-- TODO: colar o conteúdo completo do post original -->",
                DataPublicacao = new DateTime(2021, 9, 26),
                ImagemUrl = null
            },
            new NoticiaPost
            {
                Slug = "cuidados-extra-ao-dirigir-em-dias-chuvosos",
                Titulo = "Cuidados extra ao dirigir em dias chuvosos",
                ResumoCurta = "Nem sempre teremos céu azul e pista livre a nossa frente. Muitas vezes teremos que dirigir na chuva, ou começa a chover enquanto dirigimos.",
                ConteudoHtml = "<!-- TODO: colar o conteúdo completo do post original -->",
                DataPublicacao = new DateTime(2021, 9, 25),
                ImagemUrl = null
            }
        };
    }
}