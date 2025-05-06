using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CatalogoLivros.Domain.Repository;
using MediatR;

namespace CatalogoLivros.Application.Usuarios.Queries.GetUsuario
{
    public class GetUsuarioQueryHandler : IRequestHandler<GetUsuarioQuery, List<UsuarioVm>>
    {
        public readonly IUsuarioRepository _UsuarioRepository;
        private readonly IMapper _mapper;

        public GetUsuarioQueryHandler(IUsuarioRepository UsuarioRepository, IMapper mapper)
        {
            _UsuarioRepository = UsuarioRepository;
            _mapper = mapper;
        }

        public async Task<List<UsuarioVm>> Handle(GetUsuarioQuery request, CancellationToken cancellationToken)
        {
            var Usuarios = await _UsuarioRepository.GetAllUsuariosAsync();
            //var UsuarioList = Usuarios.Select(x => new UsuarioVm
            //{ Autor = x.Autor, Id = x.Id }
            //    ).ToList();

            var UsuarioList = _mapper.Map<List<UsuarioVm>>(Usuarios);
            return UsuarioList;
        }

    }
}
