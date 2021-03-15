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
        Repositorio repositorio = new Repositorio("filmes.txt");
  
        public void Atualizar(Filme filme)
        {
            string[] Registros = repositorio.RetornaRegistros();

            for (int i = 0; i < Registros.Length; i++)
            {
                string[] campos = Registros[i].Split(',');

                int idRegistro = int.Parse(campos[0]);

                if (idRegistro == filme.Id) 
                {
                    Registros[i] =  filme.Id + "," + 
                                    filme.Genero + "," + 
                                    filme.Titulo + "," + 
                                    filme.Descricao + "," + 
                                    filme.Ano + "," + 
                                    filme.Excluido;

                    File.WriteAllLines(repositorio.Diretorio, Registros);
                }
            }   
        }

        public void Excluir(int id)
        {
            string[] Registros = repositorio.RetornaRegistros();

            for (int i = 0; i < Registros.Length; i++)
            {
                string[] campos = Registros[i].Split(',');

                int idRegistro = int.Parse(campos[0]);

                if (idRegistro == id) 
                {
                    Genero genero = (Genero)Enum.Parse(typeof(Genero), campos[1]);
                    string titulo = campos[2];
                    string descricao = campos[3];
                    int ano = int.Parse(campos[4]);
                    bool excluido = true;
                    
                    Registros[i] = idRegistro + "," + 
                                genero + "," + 
                                titulo + "," + 
                                descricao + "," + 
                                ano + "," + 
                                excluido;

                    File.WriteAllLines(repositorio.Diretorio, Registros);
                }
            }   
        }

        public void Inserir(Filme novoFilme)
        {
            using (StreamWriter sw = File.AppendText(repositorio.Diretorio)) 
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
             string[] linhas = repositorio.RetornaRegistros();
             return linhas.Length;
        }

        private List<Filme> retornarTodosRegistros ()
        {
            string[] linhas =repositorio.RetornaRegistros();

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