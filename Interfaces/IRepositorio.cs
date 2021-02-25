using System.Collections.Generic;

namespace crud_series_filmes_dio.Interfaces
{
    public interface IRepositorio<T>
    {
        List<T> Listar();
        T Retornar(int id);        
        void Inserir(T entidade);        
        void Excluir(int id);        
        void Atualizar(int id, T entidade);
        int ValorId();
    }
}