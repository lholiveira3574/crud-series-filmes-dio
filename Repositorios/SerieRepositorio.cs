using System;
using System.Collections.Generic;
using crud_series_filmes_dio.Entidades;
using crud_series_filmes_dio.Interfaces;
using System.IO;
using crud_series_filmes_dio.Enums;

namespace crud_series_filmes_dio.Repositorios
{
    public class SerieRepositorio : IRepositorio<Serie>
    {
        const string diretorioArquivo = @"C:\dbtemp\series.txt";
        public void Atualizar(int id, Genero genero, string titulo, string descricao, int ano, bool excluido)
        {
            throw new System.NotImplementedException();
        }

        public void Excluir(int id)
        {
            throw new System.NotImplementedException();
        }

        public void Inserir(int id, Genero genero, string titulo, string descricao, int ano, bool excluido)
        {

            Serie novaSerie = new Serie(id, genero, titulo, descricao, ano, excluido);
            
            using (StreamWriter sw = File.AppendText(diretorioArquivo)) 
            {
                sw.WriteLine(novaSerie.Id + "," + 
                             novaSerie.Genero + "," + 
                             novaSerie.Titulo + "," + 
                             novaSerie.Descricao + "," + 
                             novaSerie.Ano + "," + 
                             novaSerie.Excluido);
            }

        }

        public List<Serie> Listar()
        {
            return retornarTodosRegistros();;
        }

        public Serie Retornar(int id)
        {
            List<Serie> series = retornarTodosRegistros();

            for (int i = 0; i < series.Count; i++)
            {
                if (series[i].Id == id)
                {
                    return new Serie(series[i].Id, 
                                     series[i].Genero, 
                                     series[i].Titulo,
                                     series[i].Descricao, 
                                     series[i].Ano, 
                                     series[i].Excluido);
                }   
            }

            return null;
        }

        public int ValorId()
        {
             string[] linhas = File.ReadAllLines(diretorioArquivo);
             return linhas.Length;
        }

        private List<Serie> retornarTodosRegistros ()
        {
            string[] linhas = File.ReadAllLines(diretorioArquivo);

            List<Serie> seriesCadastradas = new List<Serie>();

            foreach (string linha in linhas) 
            {
                string[] campos = linha.Split(',');
                int id = int.Parse(campos[0]);
                Genero genero = (Genero)Enum.Parse(typeof(Genero), campos[1]);
                string titulo = campos[2];
                string descricao = campos[3];
                int ano = int.Parse(campos[4]);
                bool excluido = bool.Parse(campos[5]);

                seriesCadastradas.Add(new Serie(id, genero, titulo, descricao, ano, excluido));
            }   

            return seriesCadastradas; 
        }
    }
}