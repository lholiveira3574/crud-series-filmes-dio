using System;
using System.IO;
using System.Collections.Generic;
using crud_series_filmes_dio.Entidades;
using crud_series_filmes_dio.Interfaces;
using crud_series_filmes_dio.Enums;


namespace crud_series_filmes_dio.Repositorios
{
    public class FilmeRepositorio : IRepositorio<Filme>
    {
        const string diretorioArquivo = @"C:\dbtemp\filmes.txt";
  
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

            Filme novoFilme = new Filme(id, genero, titulo, descricao, ano, excluido);
            
            using (StreamWriter sw = File.AppendText(diretorioArquivo)) 
            {
                sw.WriteLine(novoFilme.Id + "," + 
                             novoFilme.Genero + "," + 
                             novoFilme.Titulo + "," + 
                             novoFilme.Descricao + "," + 
                             novoFilme.Ano + "," + 
                             novoFilme.Excluido);
            }

        }

        public List<Filme> Listar()
        {
            return retornarTodosRegistros();;
        }

        public Filme Retornar(int id)
        {
            List<Filme> filmes = retornarTodosRegistros();

            for (int i = 0; i < filmes.Count; i++)
            {
                if (filmes[i].Id == id)
                {
                    return new Filme(filmes[i].Id, 
                                     filmes[i].Genero, 
                                     filmes[i].Titulo,
                                     filmes[i].Descricao, 
                                     filmes[i].Ano, 
                                     filmes[i].Excluido);
                }   
            }

            return null;
        }

        public int ValorId()
        {
             string[] linhas = File.ReadAllLines(diretorioArquivo);
             return linhas.Length;
        }

        private List<Filme> retornarTodosRegistros ()
        {
            string[] linhas = File.ReadAllLines(diretorioArquivo);

            List<Filme> filmesCadastrados = new List<Filme>();

            foreach (string linha in linhas) 
            {
                string[] campos = linha.Split(',');
                int id = int.Parse(campos[0]);
                Genero genero = (Genero)Enum.Parse(typeof(Genero), campos[1]);
                string titulo = campos[2];
                string descricao = campos[3];
                int ano = int.Parse(campos[4]);
                bool excluido = bool.Parse(campos[5]);

                filmesCadastrados.Add(new Filme(id, genero, titulo, descricao, ano, excluido));
            }   

            return filmesCadastrados; 
        }
    }
}