using System;

namespace DIO.Jogos
{
    internal class Program
    {
        static JogoRepositorio repositorio = new JogoRepositorio();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        ListarJogos();
                        break;
                    case "2":
                        InserirJogo();
                        break;
                    case "3":
                        AtualizarJogo();
                        break;
                    case "4":
                        ConcluirJogo();
                        break;
                    case "5":
                        VisualizarJogo();
                        break;
                    case "C":
                        Console.Clear();
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }

                opcaoUsuario = ObterOpcaoUsuario();
            }

            Console.WriteLine("Obrigado por utilizar nossos serviços.");
            Console.ReadLine();
        }

        private static void ConcluirJogo()
        {
            Console.Write("Digite o id do jogo: ");
            int indiceJogo = int.Parse(Console.ReadLine());

            Console.WriteLine("Tem certeza que quer marcar o jogo {0} como concluido? (S/N)", repositorio.RetornaPorId(indiceJogo).retornaTitulo());

            string opcaoUsuario = Console.ReadLine().ToUpper();
            if (opcaoUsuario == "S")
            {
                repositorio.Conclui(indiceJogo);
            }

        }

        private static void VisualizarJogo()
        {
            Console.Write("Digite o id do jogo: ");
            int indiceJogo = int.Parse(Console.ReadLine());

            var jogo = repositorio.RetornaPorId(indiceJogo);

            Console.WriteLine(jogo);
        }

        private static void AtualizarJogo()
        {
            Console.Write("Digite o id do jogo: ");
            int indiceJogo = int.Parse(Console.ReadLine());

            // https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getvalues?view=netcore-3.1
            // https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getname?view=netcore-3.1
            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.Write("Digite o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o Título do Jogo: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o Ano de Lançamento do Jogo: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a Descrição do Jogo: ");
            string entradaDescricao = Console.ReadLine();

            Jogo atualizaJogo = new Jogo(id: indiceJogo,
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao);

            repositorio.Atualiza(indiceJogo, atualizaJogo);
        }

        private static void ListarJogos()
        {
            Console.WriteLine("Listar jogos");

            var lista = repositorio.Lista();

            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhum jogo cadastrada.");
                return;
            }

            foreach (var jogo in lista)
            {
                var concluido = jogo.retornaConcluido();
                Console.WriteLine("#ID {0}: - {1} {2}", jogo.retornaId(), jogo.retornaTitulo(), (concluido ? "*Concluido*" : ""));
            }
        }

        private static void InserirJogo()
        {
            Console.WriteLine("Inserir novo jogo");

            // https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getvalues?view=netcore-3.1
            // https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getname?view=netcore-3.1
            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.Write("Digite o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o Título do Jogo: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o Ano de Lançamento do Jogo: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a Descrição do Jogo: ");
            string entradaDescricao = Console.ReadLine();

            Jogo novaJogo = new Jogo(id: repositorio.ProximoId(),
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao);

            repositorio.Insere(novaJogo);
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("DIO Jogos a seu dispor!!!");
            Console.WriteLine("Informe a opção desejada:");

            Console.WriteLine("1- Listar jogos");
            Console.WriteLine("2- Inserir novo jogo");
            Console.WriteLine("3- Atualizar jogo");
            Console.WriteLine("4- Concluir jogo");
            Console.WriteLine("5- Visualizar jogo");
            Console.WriteLine("C- Limpar Tela");
            Console.WriteLine("X- Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}