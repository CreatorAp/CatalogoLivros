using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CatalogoLivros.Application.Usuarios.Queries.GetUsuario;
using CatalogoLivros.Domain.Entity;
using CatalogoLivros.Domain.Repository;
using MediatR;

namespace CatalogoLivros.Application.Usuarios.Commands.CreateUsuario
{
    public class CreateUsuarioCommandHandler : IRequestHandler<CreateUsuarioCommand, UsuarioVm>
    {
        private readonly IUsuarioRepository _UsuarioRepository;
        private readonly IMapper _mapper;

        public CreateUsuarioCommandHandler(IUsuarioRepository UsuarioRepository, IMapper mapper)
        {
            _UsuarioRepository = UsuarioRepository;
            _mapper = mapper;
        }
        public async Task<UsuarioVm> Handle(CreateUsuarioCommand request, CancellationToken cancellationToken)
        {
            var UsuarioEnity = new Usuario()
            {
                Nome = request.Nome,
                DataNascimento = request.DataNascimento,
                Email = request.Email,
                 Senha = request.Senha,

            };
            var Result = await _UsuarioRepository.CreateAsync(UsuarioEnity);
            return _mapper.Map<UsuarioVm>(Result);
        }
    }
}
