using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogoLivros.Domain.Entity
{
    public class Livro
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public int Ibsn { get; set; }
        public string Genero { get; set; }
        public string Autor { get; set; }
        public string Editora { get; set; }
        public string Sinopse { get; set; }

        public string Foto { get; set; }
    }
}
