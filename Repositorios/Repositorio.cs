using System.IO;

namespace crud_series_filmes_dio.Repositorios
{
    public class Repositorio
    {
        private string Patch = System.AppDomain.CurrentDomain.BaseDirectory.ToString();
        private string DB = "db";
        public string Diretorio { get; private set; }
        public Repositorio(string arquivo)
        {
            Diretorio = Patch + "\\" + DB + "\\" + arquivo;

            ValidaDiretorio();
        }

        public string[] RetornaRegistros()
        {
            return File.ReadAllLines(Diretorio);
        }

        private void ValidaDiretorio()
        {
            if (File.Exists(Diretorio))
            {
                return;
            }

            Directory.CreateDirectory(Patch + DB);

            FileInfo fileInfo = new FileInfo(Diretorio);
            using (StreamWriter sw = fileInfo.CreateText())
            {
            }
        }
    }
}