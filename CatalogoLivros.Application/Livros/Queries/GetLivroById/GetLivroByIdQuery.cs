using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CatalogoLivros.Application.Livros.Queries.GetLivro;
using MediatR;

namespace CatalogoLivros.Application.Livros.Queries.GetLivroById
{
    public class GetLivroByIdQuery : IRequest<LivroVm>
    {
        public int LivroId { get; set; }
    }
}
