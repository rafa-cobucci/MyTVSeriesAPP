using System;

namespace MyTVSeriesAPP
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        static string opcaoMenu;  
        static void Main(string[] args)
        {
             string opcaoUsuario = ObterOpcaoUsuario();            

            while (opcaoUsuario.ToUpper() != "X") 
            {
                switch (opcaoUsuario)
                {
                    case "1": 
                        ListarSeries();
                        break;
                    case "2": 
                        InserirOuAtualizar();
                        break;
                    case "3": 
                        InserirOuAtualizar();
                        break;
                    case "4": 
                        ExcluirSerie();
                        break;
                    case "5": 
                        VisualizarSerie();
                        break;
                    case "C": 
                        Console.Clear();
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }

                opcaoUsuario = ObterOpcaoUsuario();
            }

            Console.WriteLine("Obrigado por utilizar nosso aplicativo.");
            Console.ReadLine();
        }

         private static void ListarSeries()
        {
            var lista = repositorio.Lista();

            if(lista.Count == 0)
            {
                Console.WriteLine("Lista de séries vazia.");
                Console.WriteLine("");
                return;
            }

            Console.WriteLine("Lista de séries:");
            Console.WriteLine("");

            foreach (var serie in lista)
            {
                var excluido = serie.retornaExcluido();

                Console.WriteLine("#Série-Id: {0} - {1} {2}", serie.Id, serie.retornaTitulo(), (excluido ? "*Excluído*" : ""));
              
            }
        } 

        private static void InserirOuAtualizar()
        {            
            if(opcaoMenu == "2")
            {
               Console.WriteLine("Inserir nova série:");

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof (Genero), i));
            }

            Console.WriteLine("Digite o número do gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());
            Console.WriteLine("Digite o título da série: ");
            string entradaTitulo = Console.ReadLine();
            Console.WriteLine("Digite a descrição da série: ");
            string entradaDescricao = Console.ReadLine();
            Console.WriteLine("Digite o ano da série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Serie novaSerie = new Serie(id: repositorio.ProximoId(),
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        descricao: entradaDescricao,
                                        ano: entradaAno);

            repositorio.Insere(novaSerie);
            Console.WriteLine("***Série inserida com sucesso.***"); 
            }

            if (opcaoMenu == "3")
            {
            Console.WriteLine("Inserir o id da série: ");
            int entradaId = int.Parse(Console.ReadLine());

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof (Genero), i));
            }

            Console.WriteLine("Digite o número do gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());
            Console.WriteLine("Digite o título da série: ");
            string entradaTitulo = Console.ReadLine();
            Console.WriteLine("Digite a descrição da série: ");
            string entradaDescricao = Console.ReadLine();
            Console.WriteLine("Digite o ano da série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Serie atualizaSerie = new Serie(id: entradaId,
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        descricao: entradaDescricao,
                                        ano: entradaAno);

            repositorio.Atualiza(entradaId, atualizaSerie);
            Console.WriteLine("***Série atualizada com sucesso.***");
            }
        }  

        private static void VisualizarSerie()
        {
            Console.WriteLine("Digite o id da série: ");
            int entradaId = int.Parse(Console.ReadLine());
            var serie = repositorio.RetornaPorId(entradaId);
            Console.WriteLine(serie);
        }

        private static void ExcluirSerie()
        {
            Console.WriteLine("Digite o id da série: ");
            int entradaId = int.Parse(Console.ReadLine());

            Console.WriteLine("Deseja mesmo deletar a série?");
            Console.WriteLine("Sim ou Não? ");
            string resposta = Console.ReadLine();
            if (resposta.ToUpper() == "SIM" || resposta.ToUpper() == "S")
            {
                repositorio.Exclui(entradaId);
                Console.WriteLine("***Série #ID: " + entradaId + " foi excluída com sucesso.***");
            }
            else if (resposta.ToUpper() == "NAO" || resposta.ToUpper() == "N" || resposta.ToUpper() == "NÃO")
            {
                Console.WriteLine("***Operação excluir série cancelada.***");
            }
            else {
                Console.WriteLine("Opção inválida.");
            }             
        }        

        private static string ObterOpcaoUsuario()
        {            
            Console.WriteLine("================================");
            Console.WriteLine("Bem vindo ao MyTVSeries APP!! ;)");
            Console.WriteLine("Informe a opção desejada:");

            Console.WriteLine("1 - Listar séries");
            Console.WriteLine("2 - Inserir nova série");
            Console.WriteLine("3 - Atualizar série");
            Console.WriteLine("4 - Excluir série");
            Console.WriteLine("5 - Visualizar série");
            Console.WriteLine("C - Limpar Tela");
            Console.WriteLine("X - Sair");
            Console.WriteLine("================================");

            Console.Write("Opção: ");
            string opcaoUsuario = Console.ReadLine();
            opcaoMenu = opcaoUsuario;            
            Console.Write("");
            return opcaoUsuario;
        }
    }
}
