using System;
using System.IO;
using crud_series_filmes_dio.Entidades.Exceptions;
using crud_series_filmes_dio.Enums;
using crud_series_filmes_dio.Views;

namespace crud_series_filmes_dio
{
    class Program
    {
        static void Main(string[] args)
        {
            try{

                Console.WriteLine("DIO Vídeos a seu dispor!!!");

                foreach (int i in Enum.GetValues(typeof(TipoConteudo)))
                {
                    Console.WriteLine("Digite {0} para {1}", i, Enum.GetName(typeof(TipoConteudo), i));
                }

                int opcaoSelecionada = int.Parse(Console.ReadLine());

                switch (opcaoSelecionada)
                {
                    case 0:
                        SerieViewHome serieViewHome = new SerieViewHome();
                        serieViewHome.AbrirTela();
                        break;
                    case 1:
                        FilmeViewHome filmeViewHome = new FilmeViewHome();
                        filmeViewHome.AbrirTela(); 
                        break;
                    default:
                        throw new DomainException("Opção selecionada é inválida");
                }
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
    }
}
