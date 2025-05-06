using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CatalogoLivros.Domain.Repository;
using MediatR;

namespace CatalogoLivros.Application.Livros.Queries.GetLivro
{
    public class GetLivroQueryHandler : IRequestHandler<GetLivroQuery, List<LivroVm>>
    {
        public readonly ILivroRepository _livroRepository;
        private readonly IMapper _mapper;

        public GetLivroQueryHandler(ILivroRepository livroRepository, IMapper mapper)
        {
            _livroRepository = livroRepository;
            _mapper = mapper;
        }

        public async Task<List<LivroVm>> Handle(GetLivroQuery request, CancellationToken cancellationToken)
        {
            var livros = await _livroRepository.GetAllLivrosAsync();
            //var livroList = livros.Select(x => new LivroVm
            //{ Autor = x.Autor, Id = x.Id }
            //    ).ToList();

            var livroList = _mapper.Map<List<LivroVm>>(livros);
            return livroList;
        }

    }
}
