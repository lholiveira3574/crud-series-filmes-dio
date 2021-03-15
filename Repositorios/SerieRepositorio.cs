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
        Repositorio repositorio = new Repositorio("series.txt");
        public void Atualizar(Serie serie)
        {
            string[] Registros = repositorio.RetornaRegistros();

            for (int i = 0; i < Registros.Length; i++)
            {
                string[] campos = Registros[i].Split(',');

                int idRegistro = int.Parse(campos[0]);

                if (idRegistro == serie.Id) 
                {
                    Registros[i] =  serie.Id + "," + 
                                    serie.Genero + "," + 
                                    serie.Titulo + "," + 
                                    serie.Descricao + "," + 
                                    serie.Ano + "," + 
                                    serie.Excluido;

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

        public void Inserir(Serie novaSerie)
        { 
            using (StreamWriter sw = File.AppendText(repositorio.Diretorio)) 
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
            var series = retornarTodosRegistros();

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
             string[] linhas = repositorio.RetornaRegistros();
             return linhas.Length;
        }

        private List<Serie> retornarTodosRegistros ()
        {
            string[] linhas = repositorio.RetornaRegistros();

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