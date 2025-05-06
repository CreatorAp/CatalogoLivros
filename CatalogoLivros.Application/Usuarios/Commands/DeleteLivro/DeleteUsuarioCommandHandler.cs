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

namespace CatalogoLivros.Application.Usuarios.Commands.DeleteUsuario
{
    public class DeleteUsuarioCommandHandler : IRequestHandler<DeleteUsuarioCommand, int>
    {
        private readonly IUsuarioRepository _UsuarioRepository;

        public DeleteUsuarioCommandHandler(IUsuarioRepository UsuarioRepository)
        {
            _UsuarioRepository = UsuarioRepository;
        }
        public async Task<int> Handle(DeleteUsuarioCommand request, CancellationToken cancellationToken)
        {
            return await _UsuarioRepository.DeleteAsync(request.Id);
        }
    }
}
