using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CatalogoLivros.Application.Usuarios.Queries.GetUsuario;
using MediatR;

namespace CatalogoLivros.Application.Usuarios.Queries.Login
{
    public class LoginQuery : IRequest<UsuarioVm>
    {
        //public string Titulo { get; set; }
        public string Nome { get; set; }
        public string DataNascimento { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
    }
}
