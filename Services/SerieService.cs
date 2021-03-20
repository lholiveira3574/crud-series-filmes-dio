using System.Collections.Generic;
using crud_series_filmes_dio.Entidades;
using crud_series_filmes_dio.Interfaces;
using crud_series_filmes_dio.Enums;
using crud_series_filmes_dio.Repositorios;

namespace crud_series_filmes_dio.Service
{
    public class SerieService : IService<Serie>
    {
        SerieRepositorio serieRepositorio = new SerieRepositorio();
        
        public void Atualizar(int id, Genero genero, string titulo, string descricao, int ano)
        {
            Serie serieAtualizada = new Serie(id, genero, titulo, descricao, ano, false);
            serieRepositorio.Atualizar(serieAtualizada);
        }

        public void Excluir(int id)
        {
            serieRepositorio.Excluir(id);
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
            return serieRepositorio.Retornar(id);
        }

        public int ValorId()
        {
            return serieRepositorio.ValorId();
        }
    }
}