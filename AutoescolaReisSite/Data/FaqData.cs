// Data/FaqData.cs
using AutoescolaReisSite.Models;

namespace AutoescolaReisSite.Data
{
    public static class FaqData
    {
        public static readonly List<FaqItem> Todas = new()
        {
            new FaqItem
            {
                Pergunta = "O que é o LADV?",
                Resposta = "LADV é a Licença para Aprendizagem de Direção Veicular. É o documento que autoriza você a realizar as aulas práticas antes de tirar a CNH definitiva, emitido pelo DETRAN após a aprovação na prova teórica."
            },
            new FaqItem
            {
                Pergunta = "Quanto tempo leva para tirar a CNH?",
                Resposta = "TODO: confirmar com o cliente o prazo médio real (varia conforme agenda de exames do DETRAN e disponibilidade de horários do aluno)."
            },
            new FaqItem
            {
                Pergunta = "Qual a diferença entre as categorias A, B, AB, D e E?",
                Resposta = "A categoria A habilita a conduzir motos e triciclos. A categoria B habilita a conduzir carros de até 8 lugares. A categoria AB combina as duas. As categorias D e E são mudanças destinadas a quem já é habilitado e quer conduzir veículos de transporte de passageiros (D) ou carretas (E)."
            },
            new FaqItem
            {
                Pergunta = "As aulas teóricas são mesmo 100% online?",
                Resposta = "Sim. As aulas teóricas podem ser feitas totalmente online, no seu tempo. As aulas práticas continuam sendo presenciais, com instrutores credenciados pelo DETRAN."
            },
            new FaqItem
            {
                Pergunta = "Quais as formas de pagamento aceitas?",
                Resposta = "TODO: confirmar com o cliente as formas de pagamento aceitas (à vista, parcelado, cartão, PIX, etc.) — texto atual do site menciona apenas \"facilitamos o pagamento\", sem detalhar."
            },
            new FaqItem
            {
                Pergunta = "Sou obrigado a fazer o curso de reciclagem?",
                Resposta = "O curso de reciclagem é obrigatório para motoristas que tiveram a CNH suspensa, ou que se envolveram em acidente de trânsito ou foram condenados judicialmente por colocar em risco a segurança no trânsito, nos termos do Código de Trânsito Brasileiro."
            }
        };
    }
}