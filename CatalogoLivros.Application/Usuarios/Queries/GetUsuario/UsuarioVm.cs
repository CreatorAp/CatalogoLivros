using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CatalogoLivros.Application.Usuarios.Common.Mappings;
using CatalogoLivros.Domain.Entity;

namespace CatalogoLivros.Application.Usuarios.Queries.GetUsuario
{
    public class UsuarioVm : IMapFrom<Usuario>
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string DataNascimento { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
    }
}
