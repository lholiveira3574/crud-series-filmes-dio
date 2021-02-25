using System;
using crud_series_filmes_dio.Entidades.Exceptions;
using crud_series_filmes_dio.Enums;
using System.IO;
using crud_series_filmes_dio.Controllers;
using System.Collections.Generic;
using crud_series_filmes_dio.Entidades;

namespace crud_series_filmes_dio
{
    class Program
    {
        static SerieController serieController = new SerieController();
        static FilmeController filmeController = new FilmeController();
        static void Main(string[] args)
        {
            try{

                Console.WriteLine("DIO Vídeos a seu dispor!!!");

                foreach (int i in Enum.GetValues(typeof(TipoConteudo)))
                {
                    Console.WriteLine("Digite {0} para {1}", i, Enum.GetName(typeof(TipoConteudo), i));
                }

                int opcaoSelecionada = int.Parse(Console.ReadLine());

                string nomeOpcaoSelecionada = Enum.GetName(typeof(TipoConteudo), opcaoSelecionada);

                string opcaoUsuario = ObterOpcaoUsuario(nomeOpcaoSelecionada);

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

                    opcaoUsuario = ObterOpcaoUsuario(nomeOpcaoSelecionada);
                }

                Console.WriteLine("Obrigado por utilizar nossos serviços.");
                Console.ReadLine();
            }
            catch (DomainException e)
			{
				Console.WriteLine("Operação abortada: {0}", e.Message);	
			}
			catch (FormatException e)
			{
				Console.WriteLine("O valor digitado é inválido: {0}", e.Message);
			}
            catch(IOException e)
			{
				Console.WriteLine("Erro ao manipular o banco de dados: {0}", e.Message);
			}
			catch(Exception e)
			{
				Console.WriteLine("Erro inesperado: {0}", e.Message);
			}
        }

        private static void Visualizar()
        {
            throw new NotImplementedException();
        }

        private static void Excluir()
        {
            throw new NotImplementedException();
        }

        private static void Atualizar()
        {
            throw new NotImplementedException();
        }

        private static void Inserir()
        {
            Console.WriteLine("Inserir nova serie");

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

        private static void Listar()
        {
            List<Serie> seriesCadastradas = serieController.Listar();

            foreach(Serie serie in seriesCadastradas)
			{
				Console.WriteLine(serie);
			}

        }

        private static string ObterOpcaoUsuario(string nomeOpcaoSelecionada)
		{
			Console.WriteLine();
            Console.WriteLine("DIO {0} a seu dispor!!!", nomeOpcaoSelecionada);
			Console.WriteLine("Informe a opção desejada:");



			Console.WriteLine("1- Listar {0}s", nomeOpcaoSelecionada);
			Console.WriteLine("2- Inserir {0}", nomeOpcaoSelecionada);
			Console.WriteLine("3- Atualizar {0}", nomeOpcaoSelecionada);
			Console.WriteLine("4- Excluir {0}", nomeOpcaoSelecionada);
			Console.WriteLine("5- Visualizar {0}", nomeOpcaoSelecionada);
			Console.WriteLine("C- Limpar Tela");
			Console.WriteLine("X- Sair");
			Console.WriteLine();

			string opcaoUsuario = Console.ReadLine().ToUpper();
			Console.WriteLine();
			return opcaoUsuario;
		}
    }
}
