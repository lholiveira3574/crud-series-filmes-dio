using System.Collections.Generic;
using crud_series_filmes_dio.Enums;
using crud_series_filmes_dio.Interfaces;

namespace crud_series_filmes_dio.Controllers
{
    public class Controller<T>
    {
        IService<T> _service;

        public Controller(IService<T> service)
        {
            _service = service;    
        }
        public void Atualizar(int id, Genero genero, string titulo, string descricao, int ano)
        {
            _service.Atualizar(id, genero, titulo, descricao, ano);
        }

        public void Excluir(int id)
        {
            _service.Excluir(id);
        }

        public void Inserir(int id, Genero genero, string titulo, string descricao, int ano, bool excluido)
        {
            _service.Inserir(id, genero, titulo, descricao, ano, excluido);
        }

        public List<T> Listar()
        {
            return _service.Listar();
        }

        public T Retornar(int id)
        {
            return _service.Retornar(id);
        }

        public int ValorId()
        {
            return _service.ValorId();
        }
    }
}