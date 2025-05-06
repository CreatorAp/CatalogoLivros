using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CatalogoLivros.Application.Livros.Queries.GetLivro;
using CatalogoLivros.Domain.Repository;
using MediatR;

namespace CatalogoLivros.Application.Livros.Queries.GetLivroById
{
    public class GetLivroByIdQueryHandler : IRequestHandler<GetLivroByIdQuery, LivroVm>
    {
        private readonly ILivroRepository _LivroRepository;
        private readonly IMapper _mapper;

        public GetLivroByIdQueryHandler(ILivroRepository LivroRepository, IMapper mapper)
        {
            _LivroRepository = LivroRepository;
            _mapper = mapper;
        }
        public async Task<LivroVm> Handle(GetLivroByIdQuery request, CancellationToken cancellationToken)
        {
            var Livro = await _LivroRepository.GetByIdLivrosAsync(request.LivroId);
            return _mapper.Map<LivroVm>(Livro);
        }
    }
}
