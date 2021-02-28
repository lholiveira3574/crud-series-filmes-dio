using System.Collections.Generic;
using crud_series_filmes_dio.Entidades;
using crud_series_filmes_dio.Interfaces;
using crud_series_filmes_dio.Enums;
using crud_series_filmes_dio.Repositorios;

namespace crud_series_filmes_dio.Service
{
    public class FilmeService : IService<Filme>
    {
        FilmeRepositorio filmeRepositorio = new FilmeRepositorio();
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
            filmeRepositorio.Inserir(id, genero, titulo, descricao, ano, excluido);
        }

        public List<Filme> Listar()
        {
            return filmeRepositorio.Listar();
        }

        public Filme Retornar(int id)
        {
             return filmeRepositorio.Retornar(id);
        }

        public int ValorId()
        {
            return filmeRepositorio.ValorId();
        }
    }
}