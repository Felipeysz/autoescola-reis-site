// Data/CursosData.cs
using AutoescolaReisSite.Models;

namespace AutoescolaReisSite.Data
{
    public static class CursosData
    {
        public static readonly CursoInfo CategoriaA = new()
        {
            Codigo = "A",
            Slug = "cnh-categoria-a",
            Titulo = "1º Habilitação Categoria “A”",
            Subtitulo = "Habilitação para pilotar motos",
            TextoIntroducao = "Habilita a conduzir veículos automotores de 2 ou 3 rodas – com ou sem carro lateral – como motocicletas, ciclomotores, motonetas e triciclos. NÃO PERMITE dirigir nenhum outro tipo de veículo automotor. Ideal para quem busca mais agilidade e mobilidade no trânsito intenso do dia a dia. A autoescola Reis oferece o curso para 1ª habilitação na categoria A, para conduzir motos, triciclos e outros.",
            CategoriaNome = "Categoria “A”",
            CategoriaDescricao = "Veículos motorizados de duas ou três rodas (Motos e Triciclos), com ou sem carro lateral.",
            Importante = "Se for aprovado, você receberá a permissão provisória para dirigir. A CNH definitiva será expedida após um ano da emissão se o condutor não tiver cometido infrações de natureza grave ou gravíssima durante esse período. O motorista também não pode ter cometido infração de natureza média mais de uma vez.",
            Etapas = new()
            {
                "Compra do Laudo",
                "Exames clínico e psicológico",
                "Aulas Teóricas (45h/aula)",
                "Realizar o simulado da prova teórica",
                "Realização da prova teórica (mediante agendamento prévio na Autoescola Reis)",
                "Retornar à Autoescola para solicitar o LADV (Licença para Aprendizagem de Direção Veicular)",
                "Realizar 20 aulas práticas",
                "Realização do exame prático (mediante agendamento prévio na Autoescola Reis)"
            },
            ImagemUrl = null
        };

        public static readonly CursoInfo CategoriaB = new()
        {
            Codigo = "B",
            Slug = "cnh-categoria-b",
            Titulo = "1º Habilitação Categoria “B”",
            Subtitulo = "Habilitação para dirigir carros",
            TextoIntroducao = "Habilita a conduzir veículos automotores com ou sem reboque, com peso bruto total (PBT) de até 3.500 kg e lotação máxima de 8 lugares, não contando o do condutor. NÃO PERMITE dirigir veículos automotores de 02 ou 03 rodas. Permite conduzir veículo automotor da espécie motor-casa cujo peso não exceda a 6.000kg, ou cuja lotação não exceda a 08 lugares, excluído o do condutor (Lei 12.452/11). Permite também conduzir trator de rodas e máquinas agrícolas (Lei 13.097/15). Ideal para quem busca conforto e segurança, principalmente para viajar com a família. O curso de 1º habilitação na categoria B, da autoescola Reis, prepara condutores de automóveis de até 8 lugares.",
            CategoriaNome = "Categoria “B”",
            CategoriaDescricao = "Veículos motorizados, não abrangidos pela categoria “A”, cujo peso bruto total não exceda a três mil e quinhentos quilogramas e cuja lotação não exceda a oito lugares, excluído o do motorista. Estão os condutores da categoria “B”, também autorizados a conduzir veículos automotores do tipo motor-casa (“MotorHome”), cujo peso não exceda a 6.000 kg, ou cuja lotação não exceda a 08 lugares, excluído o do motorista.",
            Importante = "Se for aprovado, você receberá a permissão provisória para dirigir. A CNH definitiva será expedida após um ano da emissão se o condutor não tiver cometido infrações de natureza grave ou gravíssima durante esse período. O motorista também não pode ter cometido infração de natureza média mais de uma vez.",
            Etapas = new()
            {
                "Compra do Laudo",
                "Exames clínico e psicológico",
                "Aulas Teóricas (45h/aula)",
                "Realizar o simulado da prova teórica",
                "Realização da prova teórica (mediante agendamento prévio na Autoescola Reis)",
                "Retornar à Autoescola para solicitar o LADV (Licença para Aprendizagem de Direção Veicular)",
                "Realizar 20 aulas práticas",
                "Realização do exame prático (mediante agendamento prévio na Autoescola Reis)"
            },
            ImagemUrl = null
        };

        public static readonly CursoInfo CategoriaAB = new()
        {
            Codigo = "AB",
            Slug = "cnh-categoria-ab",
            Titulo = "1º Habilitação Categoria “A e B”",
            Subtitulo = "Habilitação para conduzir carros e motos",
            TextoIntroducao = "Curso para quem desejar adquirir a habilitação simultaneamente nas categorias \"A\" e \"B\". Além de poder tirar a primeira habilitação nas categorias “A” e “B” de forma separada, na Autoescola Reis você pode fazer os dois cursos simultaneamente, o que habilita o condutor a dirigir carros e pilotar motos.",
            CategoriaNome = "Categoria “AB”",
            CategoriaDescricao = "Veículos motorizados de duas ou três rodas (Motos e Triciclos), com ou sem carro lateral, da categoria “A” e veículos motorizados da categoria “B”, cujo peso bruto total não exceda a três mil e quinhentos quilogramas e cuja lotação não exceda a oito lugares, excluído o do motorista. Estão os condutores da categoria “AB”, também autorizados a conduzir veículos automotores do tipo motor-casa (“MotorHome”), cujo peso não exceda a 6.000 kg, ou cuja lotação não exceda a 08 lugares, excluído o do motorista.",
            Importante = "Se for aprovado, você receberá a permissão provisória para dirigir. A CNH definitiva será expedida após um ano da emissão se o condutor não tiver cometido infrações de natureza grave ou gravíssima durante esse período. O motorista também não pode ter cometido infração de natureza média mais de uma vez.",
            Etapas = new()
            {
                "Compra do Laudo",
                "Exames clínico e psicológico",
                "Aulas Teóricas (45h/aula)",
                "Realizar o simulado da prova teórica",
                "Realização da prova teórica (mediante agendamento prévio na Autoescola Reis)",
                "Retornar à Autoescola para solicitar o LADV (Licença para Aprendizagem de Direção Veicular)",
                "Realizar 20 aulas práticas de Carro",
                "Realizar 20 aulas práticas de Moto",
                "Realização do exame prático (mediante agendamento prévio na Autoescola Reis)"
            },
            ImagemUrl = null
        };

        public static readonly CursoInfo AdicaoCategoria = new()
        {
            Codigo = "+",
            Slug = "adicao-categoria",
            Titulo = "Adição de Categoria",
            Subtitulo = "Adicionar categoria “A” ou “B”",
            TextoIntroducao = "Serviço para condutores que já possuem CNH nas Categorias “A” ou “B” e pretendem torná-las Categoria “AB”. Este curso foi desenvolvido para as pessoas que já possuem habilitação na categoria “A” ou “B” e deseja adicionar a outra categoria. Ideal para pessoas que desejam a praticidade da motocicleta em certas situações e o conforto e segurança do carro em outras.",
            EtapasPorGrupo = new()
            {
                ["Etapas necessárias para a adição da categoria A"] = new()
                {
                    "Realizar curso prático de, no mínimo, 15h/aula em veículo de aprendizagem, sendo 03h/aula no período noturno",
                    "Realização do exame prático (mediante agendamento prévio na Autoescola Reis)"
                },
                ["Etapas necessárias para a adição da categoria B"] = new()
                {
                    "Realizar curso prático de no mínimo 15h/aula em veículo de aprendizagem, sendo 03h/aulas no período noturno",
                    "Realização do exame prático (mediante agendamento prévio na Autoescola Reis)"
                }
            },
            ImagemUrl = null
        };

        public static readonly CursoInfo CategoriaD = new()
        {
            Codigo = "D",
            Slug = "cnh-categoria-d",
            Titulo = "Mudança para Categoria “D”",
            Subtitulo = "Habilitação para transporte de passageiros",
            TextoIntroducao = "Curso destinado a condutores habilitados nas Categorias \"B\" ou “C”, que desejam conduzir transportes de passageiros. Permite dirigir todos os veículos das categorias “B” e “C” e veículos de passageiros com lotação maior que 08 (oito) lugares.",
            CategoriaNome = "Categoria “D”",
            CategoriaDescricao = "Veículos utilizados no transporte de passageiros, cuja lotação exceda a 08 passageiros, excluindo o motorista. Nesta categoria também estão autorizados a conduzir veículos automotores do tipo motor-casa (“MotorHome”), com lotação acima de 08 lugares, excluído o do motorista, além de veículos abrangidos pela categoria “B” e “C”.",
            Exigencias = new()
            {
                "Ser habilitado na categoria C por pelo menos 01 ano, ou no mínimo 02 anos na categoria “B”",
                "Ter mais de 21 anos e ser aprovado em exame de aptidão física e mental",
                "Não estar com a CNH suspensa",
                "Realizar 20 aulas práticas, sendo 03 delas à noite",
                "Realizar um exame prático de direção veicular"
            },
            Etapas = new()
            {
                "Compra do Laudo",
                "Exame Médico",
                "Psicoteste",
                "Exame Toxicológico",
                "Aulas Práticas",
                "Exame Prático de Direção Veicular"
            },
            ImagemUrl = null
        };

        public static readonly CursoInfo CategoriaE = new()
        {
            Codigo = "E",
            Slug = "cnh-categoria-e",
            Titulo = "Mudança para Categoria “E”",
            Subtitulo = "Habilitação para conduzir caminhões e carretas",
            TextoIntroducao = "Curso destinado a condutores habilitados na Categoria \"C\" (2 anos) ou \"D\" (1 ano), que desejam conduzir carretas. Permite conduzir todos os veículos das categorias “C” e “D”, trailers e veículos que rebocam unidades com mais de 6.000kg de PBT (peso bruto total) ou com lotação superior a 08 passageiros. É a única categoria que permite conduzir veículos com mais de um reboque.",
            CategoriaNome = "Categoria “E”",
            CategoriaDescricao = "Combinação de veículos em que a unidade tratora se enquadre nas categorias “C” ou “D” e cuja unidade acoplada, reboque, semirreboque, trailer ou articulada tenha 6.000 kg (seis mil quilogramas) ou mais de peso bruto total, ou cuja lotação exceda a 8 (oito) lugares. Nesta categoria também se enquadra o condutor de combinação de veículos com mais de uma unidade tracionada, independentemente da capacidade de tração ou do peso bruto total.",
            Exigencias = new()
            {
                "Estar habilitado há pelo menos 02 anos na categoria “C” ou 01 ano na categoria \"D\"",
                "Ter mais de 21 anos e ser aprovado em exame de aptidão física e mental",
                "Não estar com a CNH suspensa",
                "Realizar 20 aulas práticas",
                "Realizar um exame prático de direção veicular"
            },
            Etapas = new()
            {
                "Compra do Laudo",
                "Exame Médico",
                "Psicoteste",
                "Exame Toxicológico",
                "Aulas Práticas",
                "Exame Prático de Direção Veicular"
            },
            ImagemUrl = null
        };

        public static readonly CursoInfo Reciclagem = new()
        {
            Codigo = "R",
            Slug = "curso-reciclagem",
            Titulo = "Curso de Reciclagem",
            Subtitulo = "Reciclagem para condutores cumprindo penalidades",
            TextoIntroducao = "A Autoescola Reis, como centro de formação cadastrado pelo DETRAN – BA, oferece o curso de reciclagem da CNH, com objetivo de relembrar aos motoristas infratores sobre as regras do trânsito e outros conhecimentos importantes para uma direção responsável. Autoescola Reis oferece o curso de reciclagem para quem cumpre penalidade de suspensão ou cassação da CNH.",
            Exigencias = new()
            {
                "Motoristas que tiveram sua CNH suspensa",
                "Condutores que se envolveram em algum acidente de trânsito ou que foram condenados judicialmente por colocar em risco a segurança no trânsito nos termos do Art. 261, § 2º, e Art. 268 do Código de Trânsito Brasileiro"
            },
            Etapas = new()
            {
                "Legislação",
                "Direção Defensiva",
                "Primeiros Socorros",
                "Relacionamento Interpessoal"
            },
            ImagemUrl = null
        };

        public static readonly List<CursoInfo> Todos = new()
        {
            CategoriaA, CategoriaB, CategoriaAB, AdicaoCategoria, CategoriaD, CategoriaE, Reciclagem
        };
    }
}