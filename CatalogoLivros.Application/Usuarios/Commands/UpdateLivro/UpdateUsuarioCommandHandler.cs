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

namespace CatalogoLivros.Application.Usuarios.Commands.UpdateUsuario
{
    public class UpdateUsuarioCommandHandler : IRequestHandler<UpdateUsuarioCommand, int>
    {
        private readonly IUsuarioRepository _UsuarioRepository;

        public UpdateUsuarioCommandHandler(IUsuarioRepository UsuarioRepository)
        {
            _UsuarioRepository = UsuarioRepository;
        }
        public async Task<int> Handle(UpdateUsuarioCommand request, CancellationToken cancellationToken)
        {
            var UdateUsuarioEntity = new Usuario()
            {
                Id = request.Id,
                 Nome = request.Nome,
                 DataNascimento = request.DataNascimento,
                 Email = request.Email,
                 Senha = request.Senha,
            };

            return await _UsuarioRepository.UpdateAsync(request.Id, UdateUsuarioEntity);
        }
    }
}
