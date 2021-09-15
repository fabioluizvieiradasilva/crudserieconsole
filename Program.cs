using System;
using series.Repositorios;
using series.Enum;
using series.Classes;

namespace series
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {            
            string opcaoUsuario = OpcaoUsuario();
            while(opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        ListarSeries();
                        break;

                    case "2":
                        InserirSerie();
                        break;

                    case "3":
                        AtualizarSerie();
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

                    case "X":
                        break;
                    
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                opcaoUsuario = OpcaoUsuario();
            }
            
        }

        private static void ListarSeries()
        {
            Console.WriteLine("*** Listar Séries ***");
            var lista = repositorio.Lista();

            if(lista.Count == 0)
            {
                Console.WriteLine("Não há séries cadastradas");
                return;
            }

            foreach(var serie in lista)
            {
                var excluido = serie.retornaExluido();
                Console.WriteLine("#ID {0}: - {1} - {2}", serie.retornaId(), serie.retornaTitulo(), (excluido ? "*Excluído*": ""));
            }
        }
        private static void InserirSerie()
        {
            Console.WriteLine("*** Inserir nova Série ***");
            foreach (int i in Enum.Genero.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1}", i, Enum.Genero.GetName(typeof(Genero),i));
            }
            Console.Write("Digite o gênero de acordo com as opções acima: ");
            int genero = int.Parse(Console.ReadLine());

            Console.Write("Digite o título da série: ");
            string titulo = Console.ReadLine();

            Console.Write("Digite a descrição da série: ");
            string descricao = Console.ReadLine();

            Console.Write("Digite o ano da série: ");
            int ano = int.Parse(Console.ReadLine());

            Serie serie = new Serie(id: repositorio.ProximoId(),
                titulo,
                (Genero)genero,
                descricao,
                ano
            );
            repositorio.Insere(serie);
        }
        private static void AtualizarSerie()        
        {
            Console.WriteLine("*** Atualizar serie Série ***");
            Console.Write("Qual série deseja alterar");
            int id = int.Parse(Console.ReadLine());
            if(repositorio.RetornaPorId(id) == null)
            {
                Console.WriteLine("Série não encontrada");
                return;
            }
            foreach (int i in Enum.Genero.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1}", i, Enum.Genero.GetName(typeof(Genero),i));
            }
            Console.Write("Digite o gênero de acordo com as opções acima: ");
            int genero = int.Parse(Console.ReadLine());

            Console.Write("Digite o título da série: ");
            string titulo = Console.ReadLine();

            Console.Write("Digite a descrição da série: ");
            string descricao = Console.ReadLine();

            Console.Write("Digite o ano da série: ");
            int ano = int.Parse(Console.ReadLine());

            Serie serie = new Serie(id,
                titulo,
                (Genero)genero,
                descricao,
                ano
            );

            repositorio.Atualiza(id, serie);
        }
        private static void ExcluirSerie()
        {
            Console.WriteLine("Qual série você deseja exlcuir?");
            int id  = int.Parse(Console.ReadLine());
            var serie = repositorio.RetornaPorId(id);
            if(serie == null)
            {
                Console.WriteLine("Série não encontrada");
                return;
            }

            Console.Write("Deseja realmente excluir a série {0}", serie.retornaTitulo());
            char resp = char.Parse(Console.ReadLine().ToUpper());
            if(resp == 'S')
            {
                repositorio.Excluir(id);
            }            
        }
        private static string OpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("Lista de Séries Lugagi");
            Console.WriteLine("Informe a opção desejada:");

            Console.WriteLine("1- Listar séries");
            Console.WriteLine("2- Inserir nova série");
            Console.WriteLine("3- Atualizar série");
            Console.WriteLine("4- Excluir série");
            Console.WriteLine("5- Visualizar série");
            Console.WriteLine("C- Limpar tela");
            Console.WriteLine("X- Sair");

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;

        }
        private static void VisualizarSerie()
        {
            Console.Write("Informe a série que deseja visualizar: ");
            var serie = repositorio.RetornaPorId(int.Parse(Console.ReadLine()));

            Console.WriteLine(serie);
        }
    
    }
}
