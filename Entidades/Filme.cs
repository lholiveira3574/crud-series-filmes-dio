using crud_series_filmes_dio.Enums;

namespace crud_series_filmes_dio.Entidades
{
    public class Filme
    {
        public int Id {get; private set;} 
        private Genero Genero { get; set; }
		private string Titulo { get; set; }
		private string Descricao { get; set; }
		private int Ano { get; set; }
        private bool Excluido {get; set;} 

        public Filme(int id, Genero genero, string titulo, string descricao, int ano)
        {
            this.Id = id;
			this.Genero = genero;
			this.Titulo = titulo;
			this.Descricao = descricao;
			this.Ano = ano;
            this.Excluido = false;    
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
            return  "Numero da Conta: " + this.Id + " | " +
                    "Genero: " + this.Genero + " | " +
                    "Titulo: " + this.Titulo + " | "+
                    "Ano de Início: " + this.Ano + " | " +
                    "Excluido: " + this.Excluido;

		}   
    }
}