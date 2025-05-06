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

namespace CatalogoLivros.Application.Livros.Commands.DeleteLivro
{
    public class DeleteLivroCommandHandler : IRequestHandler<DeleteLivroCommand, int>
    {
        private readonly ILivroRepository _LivroRepository;

        public DeleteLivroCommandHandler(ILivroRepository LivroRepository)
        {
            _LivroRepository = LivroRepository;
        }
        public async Task<int> Handle(DeleteLivroCommand request, CancellationToken cancellationToken)
        {
            return await _LivroRepository.DeleteAsync(request.Id);
        }
    }
}
