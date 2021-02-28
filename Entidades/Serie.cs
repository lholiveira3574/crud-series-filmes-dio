using crud_series_filmes_dio.Enums;

namespace crud_series_filmes_dio.Entidades
{
    public class Serie
    {
        public int Id {get; private set;} 
        public Genero Genero { get; private set; }
		public string Titulo { get; private set; }
		public string Descricao { get; private set; }
		public int Ano { get; private set; }
        public bool Excluido {get; private set;}

        public Serie(int id, Genero genero, string titulo, string descricao, int ano, bool excluido)
        {
            this.Id = id;
			this.Genero = genero;
			this.Titulo = titulo;
			this.Descricao = descricao;
			this.Ano = ano;
            this.Excluido = excluido;    
        }

        public string retornaTitulo()
        {
			return this.Titulo;
		}

        public bool retornaExcluido()
		{
			return this.Excluido;
		}

        public void Excluir() {
            this.Excluido = true;
        }

        public override string ToString()
		{
            return  "Id da Série: " + this.Id + " | " +
                    "Genero: " + this.Genero + " | " +
                    "Titulo: " + this.Titulo + " | "+
                    "Ano de Início: " + this.Ano + " | " +
                    "Excluido: " + this.Excluido;

		}
        
    }
}