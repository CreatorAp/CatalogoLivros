using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CatalogoLivros.Application.Usuarios.Queries.GetUsuario;
using CatalogoLivros.Domain.Repository;
using MediatR;

namespace CatalogoLivros.Application.Usuarios.Queries.Login
{
    public class LoginQueryHandler : IRequestHandler<LoginQuery, UsuarioVm>
    {
        public readonly IUsuarioRepository _UsuarioRepository;
        private readonly IMapper _mapper;

        public LoginQueryHandler(IUsuarioRepository UsuarioRepository, IMapper mapper)
        {
            _UsuarioRepository = UsuarioRepository;
            _mapper = mapper;
        }

        public async Task<UsuarioVm> Handle(LoginQuery request, CancellationToken cancellationToken)
        {
            var Usuarios = await _UsuarioRepository.GetAllUsuariosAsync(); //.Result.SingleOrDefault(u => u.Email == request.Email );
            var UsuarioLogin = Usuarios.SingleOrDefault(u => u.Email == request.Email && u.Senha == request.Senha);
            //    .Select(x => new UsuarioVm
            //{ Autor = x.Autor, Id = x.Id }
            //    ).ToList();

            var Usuario = _mapper.Map<UsuarioVm>(UsuarioLogin);
            return Usuario;
        }

    }
}
