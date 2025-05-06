using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CatalogoLivros.Application.Usuarios.Queries.GetUsuario;
using CatalogoLivros.Domain.Repository;
using MediatR;

namespace CatalogoLivros.Application.Usuarios.Queries.GetUsuarioById
{
    public class GetUsuarioByIdQueryHandler : IRequestHandler<GetUsuarioByIdQuery, UsuarioVm>
    {
        private readonly IUsuarioRepository _UsuarioRepository;
        private readonly IMapper _mapper;

        public GetUsuarioByIdQueryHandler(IUsuarioRepository UsuarioRepository, IMapper mapper)
        {
            _UsuarioRepository = UsuarioRepository;
            _mapper = mapper;
        }
        public async Task<UsuarioVm> Handle(GetUsuarioByIdQuery request, CancellationToken cancellationToken)
        {
            var Usuario = await _UsuarioRepository.GetByIdUsuariosAsync(request.UsuarioId);
            return _mapper.Map<UsuarioVm>(Usuario);
        }
    }
}
