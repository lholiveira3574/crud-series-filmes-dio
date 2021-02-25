using System.Collections.Generic;
using crud_series_filmes_dio.Entidades;
using crud_series_filmes_dio.Enums;
using crud_series_filmes_dio.Repositorios;

namespace crud_series_filmes_dio.Controllers
{
    public class SerieController
    {
        SerieRepositorio serieRepositorio = new SerieRepositorio();
        public void Atualizar(int id, Serie objeto)
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
            serieRepositorio.Inserir(novaSerie);
        }

        public List<Serie> Listar()
        {
            return serieRepositorio.Listar();
        }

        public Serie Retornar(int id)
        {
            throw new System.NotImplementedException();
        }

        public int ValorId()
        {
            return serieRepositorio.ValorId();
        }
    }
}