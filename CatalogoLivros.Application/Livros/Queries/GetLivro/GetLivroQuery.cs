﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace CatalogoLivros.Application.Livros.Queries.GetLivro
{
    public class GetLivroQuery : IRequest<List<LivroVm>>
    {
        public string Titulo { get; set; }
        public int Ibsn { get; set; }
        public string Genero { get; set; }
        public string Autor { get; set; }
        public string Editora { get; set; }
        public string Sinopse { get; set; }

        public string Foto { get; set; }
    }
}
