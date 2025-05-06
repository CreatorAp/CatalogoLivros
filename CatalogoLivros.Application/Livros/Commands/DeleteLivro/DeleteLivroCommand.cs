using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CatalogoLivros.Application.Livros.Queries.GetLivro;
using MediatR;

namespace CatalogoLivros.Application.Livros.Commands.DeleteLivro
{
    public class DeleteLivroCommand : IRequest<int>
    {
        public int Id { get; set; }
    }
}
