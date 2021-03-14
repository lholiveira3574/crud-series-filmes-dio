using System.Collections.Generic;
using crud_series_filmes_dio.Enums;

namespace crud_series_filmes_dio.Interfaces
{
    public interface IRepositorio<T>
    {
        List<T> Listar();
        T Retornar(int id);        
        void Inserir(T entidade);        
        void Excluir(int id);        
        void Atualizar(T entidade);
        int ValorId();
    }
}