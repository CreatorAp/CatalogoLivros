using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CatalogoLivros.Application.Usuarios.Queries.GetUsuario;
using MediatR;

namespace CatalogoLivros.Application.Usuarios.Commands.DeleteUsuario
{
    public class DeleteUsuarioCommand : IRequest<int>
    {
        public int Id { get; set; }
    }
}
