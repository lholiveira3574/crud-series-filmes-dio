using crud_series_filmes_dio.Enums;

namespace crud_series_filmes_dio.Entidades
{
    public class Filme
    {
        public int Id {get; private set;} 
        public Genero Genero { get; private set; }
		public string Titulo { get; private set; }
		public string Descricao { get; private set; }
		public int Ano { get; private set; }
        public bool Excluido {get; private set;} 

        public Filme(int id, Genero genero, string titulo, string descricao, int ano, bool excluido)
        {
            this.Id = id;
			this.Genero = genero;
			this.Titulo = titulo;
			this.Descricao = descricao;
			this.Ano = ano;
            this.Excluido = excluido;    
        }

        public override string ToString()
		{
            return  "Id do Filme: " + this.Id + " | " +
                    "Genero: " + this.Genero + " | " +
                    "Titulo: " + this.Titulo + " | "+
                    "Ano de Início: " + this.Ano + " | " +
                    "Excluido: " + this.Excluido;

		}   
    }
}