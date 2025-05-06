using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CatalogoLivros.Application.Livros.Queries.GetLivro;
using CatalogoLivros.Domain.Entity;
using CatalogoLivros.Domain.Repository;
using MediatR;

namespace CatalogoLivros.Application.Livros.Commands.CreateLivro
{
    public class CreateLivroCommandHandler : IRequestHandler<CreateLivroCommand, LivroVm>
    {
        private readonly ILivroRepository _LivroRepository;
        private readonly IMapper _mapper;

        public CreateLivroCommandHandler(ILivroRepository LivroRepository, IMapper mapper)
        {
            _LivroRepository = LivroRepository;
            _mapper = mapper;
        }
        public async Task<LivroVm> Handle(CreateLivroCommand request, CancellationToken cancellationToken)
        {
            var LivroEnity = new Livro()
            {
                Titulo = request.Titulo,
                Ibsn = request.Ibsn,
                Genero = request.Genero,
                Autor = request.Autor,
                Editora = request.Editora,
                Sinopse = request.Sinopse,
            };
            var Result = await _LivroRepository.CreateAsync(LivroEnity);
            return _mapper.Map<LivroVm>(Result);
        }
    }
}
