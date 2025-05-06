using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace CatalogoLivros.Application.Usuarios.Queries.GetUsuario
{
    public class GetUsuarioQuery : IRequest<List<UsuarioVm>>
    {
        public string Titulo { get; set; }
        public int Ibsn { get; set; }
        public string Genero { get; set; }
        public string Autor { get; set; }
        public string Editora { get; set; }
        public string Sinopse { get; set; }

        public string Foto { get; set; }

        public string Email { get; set; }
        public string Senha { get; set; }
        public string Nnome { get; set; }
        public string datanascimento { get; set; }
    }
}
