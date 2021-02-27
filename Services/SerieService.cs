using System;
using System.Collections.Generic;
using crud_series_filmes_dio.Entidades;
using crud_series_filmes_dio.Interfaces;
using System.IO;
using crud_series_filmes_dio.Enums;
using crud_series_filmes_dio.Repositorios;

namespace crud_series_filmes_dio.Service
{
    public class SerieService : IService<Serie>
    {
        SerieRepositorio serieRepositorio = new SerieRepositorio();
        
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
            serieRepositorio.Inserir(id, genero, titulo, descricao, ano, excluido);
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