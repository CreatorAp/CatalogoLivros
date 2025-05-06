using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CatalogoLivros.Application.Usuarios.Queries.GetUsuario;
using MediatR;

namespace CatalogoLivros.Application.Usuarios.Queries.GetUsuarioById
{
    public class GetUsuarioByIdQuery : IRequest<UsuarioVm>
    {
        public int UsuarioId { get; set; }
    }
}
