using System.Collections.Generic;
using crud_series_filmes_dio.Enums;

namespace crud_series_filmes_dio.Interfaces
{
    public interface IController<T>
    {
        List<T> Listar();
        T Retornar(int id);        
        void Inserir(int id, Genero genero, string titulo, string descricao, int ano, bool excluido);        
        void Excluir(int id);        
        void Atualizar(int id, Genero genero, string titulo, string descricao, int ano, bool excluido);
        int ValorId();
    }
}