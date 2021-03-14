using System;
using crud_series_filmes_dio.Controllers;
using crud_series_filmes_dio.Entidades;
using crud_series_filmes_dio.Entidades.Exceptions;
using crud_series_filmes_dio.Enums;
using crud_series_filmes_dio.Service;

namespace crud_series_filmes_dio.Views
{
    public class FilmeViewHome
    {
        Controller<Filme> filmeController = new Controller<Filme>(new FilmeService());

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

			Console.WriteLine("1- Listar Filmes");
			Console.WriteLine("2- Inserir Filme");
			Console.WriteLine("3- Atualizar Filme");
			Console.WriteLine("4- Excluir Filme");
			Console.WriteLine("5- Visualizar Filme");
			Console.WriteLine("C- Limpar Tela");
			Console.WriteLine("X- Sair");
			Console.WriteLine();

			string opcaoUsuario = Console.ReadLine().ToUpper();
			Console.WriteLine();
			return opcaoUsuario;
		}

        private void Visualizar()
        {
            Console.Write("Digite o id do Filme: ");
			int id = int.Parse(Console.ReadLine());

			var filmeEncontrado = filmeController.Retornar(id);

            if (filmeEncontrado != null)
                Console.WriteLine(filmeEncontrado);    
            else
                Console.WriteLine(MensagemFilmeNaoEncontrado(id)); 
        }

        private void Excluir()
        {
            Console.Write("Digite o id do filme: ");
			int id = int.Parse(Console.ReadLine());

            if (FilmeExiste(id))
            {
                filmeController.Excluir(id);
                Console.WriteLine("Filme de id {0} foi excluido com sucesso!", id);
            }
            else
            {
                Console.WriteLine(MensagemFilmeNaoEncontrado(id));
            }
			
        }

        private void Atualizar()
        {
            Console.Write("Digite o id do Filme: ");
			int id = int.Parse(Console.ReadLine());

            if (FilmeExiste(id))
            {

                foreach (int i in Enum.GetValues(typeof(Genero)))
                {
                    Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
                }
                Console.Write("Digite o gênero entre as opções acima: ");
                int genero = int.Parse(Console.ReadLine());

                Console.Write("Digite o Título do Filme: ");
                string titulo = Console.ReadLine();

                Console.Write("Digite o Ano de Início do Filme: ");
                int ano = int.Parse(Console.ReadLine());

                Console.Write("Digite a Descrição do Filme: ");
                string descricao = Console.ReadLine();

                filmeController.Atualizar(id, (Genero)genero, titulo, descricao, ano);

                Console.WriteLine("Filme de id {0} foi atualizado com sucesso!", id);
            }
            else
            {
                Console.WriteLine(MensagemFilmeNaoEncontrado(id));    
            }
        }

        private void Inserir()
        {
            Console.WriteLine("Inserir novo Filme");

            int id = filmeController.ValorId();

			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("Digite {0} para {1}", i, Enum.GetName(typeof(Genero), i));
			}
			Console.Write("Digite o gênero entre as opções acima: ");
			int genero = int.Parse(Console.ReadLine());

			Console.Write("Digite o Título do Filme: ");
			string titulo = Console.ReadLine();

			Console.Write("Digite o Ano de Início do Filme: ");
			int ano = int.Parse(Console.ReadLine());

			Console.Write("Digite a Descrição do Filme: ");
			string descricao = Console.ReadLine();

            filmeController.Inserir(id, (Genero)genero, titulo, descricao, ano, false);

            Console.WriteLine("Cadastro realizado com sucesso!");
        }

        private void Listar()
        {
            var filmesCadastrados = filmeController.Listar();

            if (filmesCadastrados.Count <= 0)
            {
                Console.WriteLine("Nenhum filme está cadastrado!");
            }
            else
            {
                foreach( var filmes in filmesCadastrados)
                {
                    Console.WriteLine(filmes);
                }
            }
        }

        private bool FilmeExiste(int id)
        {
            var filmesCadastradas = filmeController.Listar();

            for (int i = 0; i < filmesCadastradas.Count; i++)
            {
                if(filmesCadastradas[i].Id == id)
                {
                    return true;
                }  
            }

            return false;
        }

        private string MensagemFilmeNaoEncontrado(int id)
        {
            return "Filme de id " + id + " não foi encontrado!";
        }
    }
}