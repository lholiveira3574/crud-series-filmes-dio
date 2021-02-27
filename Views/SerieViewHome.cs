using System;
using crud_series_filmes_dio.Controllers;
using crud_series_filmes_dio.Entidades;
using crud_series_filmes_dio.Entidades.Exceptions;
using crud_series_filmes_dio.Enums;
using crud_series_filmes_dio.Service;

namespace crud_series_filmes_dio.Views
{
    public class SerieViewHome
    {
        Controller<Serie> serieController = new Controller<Serie>(new SerieService());

        public void AbrirTela()
        {
            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        Listar();
                        break;
                    case "2":
                        Inserir();
                        break;
                    case "3":
                        Atualizar();
                        break;
                    case "4":
                        Excluir();
                        break;
                    case "5":
                        Visualizar();
                        break;
                    case "C":
                        Console.Clear();
                        break;

                    default:
                        throw new DomainException("Opção selecionada é inválida");
                }

                opcaoUsuario = ObterOpcaoUsuario();
            }
        }
        private string ObterOpcaoUsuario()
		{
            Console.WriteLine();
			Console.WriteLine("Informe a opção desejada:");

			Console.WriteLine("1- Listar Séries");
			Console.WriteLine("2- Inserir Série");
			Console.WriteLine("3- Atualizar Série");
			Console.WriteLine("4- Excluir Série");
			Console.WriteLine("5- Visualizar Série");
			Console.WriteLine("C- Limpar Tela");
			Console.WriteLine("X- Sair");
			Console.WriteLine();

			string opcaoUsuario = Console.ReadLine().ToUpper();
			Console.WriteLine();
			return opcaoUsuario;
		}

        private void Visualizar()
        {
            Console.Write("Digite o id da série: ");
			int id = int.Parse(Console.ReadLine());

			var serieEncontrada = serieController.Retornar(id);

			Console.WriteLine(serieEncontrada);
        }

        private void Excluir()
        {
            throw new NotImplementedException();
        }

        private void Atualizar()
        {
            throw new NotImplementedException();
        }

        private void Inserir()
        {
            Console.WriteLine("Inserir nova Série");

            int id = serieController.ValorId();

			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("Digite {0} para {1}", i, Enum.GetName(typeof(Genero), i));
			}
			Console.Write("Digite o gênero entre as opções acima: ");
			int genero = int.Parse(Console.ReadLine());

			Console.Write("Digite o Título da Série: ");
			string titulo = Console.ReadLine();

			Console.Write("Digite o Ano de Início da Série: ");
			int ano = int.Parse(Console.ReadLine());

			Console.Write("Digite a Descrição da Série: ");
			string descricao = Console.ReadLine();

            serieController.Inserir(id, (Genero)genero, titulo, descricao, ano, false);

            Console.WriteLine("Cadastro realizado com sucesso!");
        }

        private void Listar()
        {
            var seriesCadastradas = serieController.Listar();

            foreach(var series in seriesCadastradas)
			{
				Console.WriteLine(series);
			}

        }
    }
}