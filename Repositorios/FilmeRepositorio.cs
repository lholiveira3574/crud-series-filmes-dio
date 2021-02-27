using System.Collections.Generic;
using crud_series_filmes_dio.Entidades;
using crud_series_filmes_dio.Interfaces;
using System.IO;
using crud_series_filmes_dio.Enums;

namespace crud_series_filmes_dio.Repositorios
{
    public class FilmeRepositorio : IRepositorio<Filme>
    {
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
            throw new System.NotImplementedException();
        }

        public List<Filme> Listar()
        {
            throw new System.NotImplementedException();
        }

        public Filme Retornar(int id)
        {
            throw new System.NotImplementedException();
        }

        public int ValorId()
        {
            throw new System.NotImplementedException();
        }
    }
}