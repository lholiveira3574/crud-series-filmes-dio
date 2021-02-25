using System;

namespace crud_series_filmes_dio.Entidades.Exceptions
{
    public class DomainException : ApplicationException
    {
        public DomainException(string message): base(message)
        {   
        }
    }
}