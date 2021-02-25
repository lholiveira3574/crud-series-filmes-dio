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
        private List<Serie> listaSerie = new List<Serie>();
        public void Atualizar(int id, Serie obj)
        {
            throw new System.NotImplementedException();
        }

        public void Excluir(int id)
        {
            throw new System.NotImplementedException();
        }

        public void Inserir(Serie obj)
        {
            
            using (StreamWriter sw = File.AppendText(diretorioArquivo)) 
            {
                sw.WriteLine(obj.Id + "," + obj.Genero + "," + obj.Titulo + "," + obj.Descricao + "," + obj.Ano + "," + obj.Excluido);
            }

        }

        public List<Serie> Listar()
        {
            string[] linhas = File.ReadAllLines(diretorioArquivo);

            List<Serie> listaSerie = new List<Serie>();

            foreach (string linha in linhas) 
            {
                string[] campos = linha.Split(',');
                int id = int.Parse(campos[0]);
                Genero genero = (Genero)Enum.Parse(typeof(Genero), campos[1]);
                string titulo = campos[2];
                string descricao = campos[3];
                int ano = int.Parse(campos[4]);
                bool excluido = bool.Parse(campos[5]);

                Serie serie = new Serie(id, genero, titulo, descricao, ano, excluido);

                listaSerie.Add(serie);
            }

            return listaSerie;
        }

        public Serie Retornar(int id)
        {
            throw new System.NotImplementedException();
        }

        public int ValorId()
        {
             string[] linhas = File.ReadAllLines(diretorioArquivo);
             return linhas.Length;
        }
    }
}