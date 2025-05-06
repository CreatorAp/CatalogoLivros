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

namespace CatalogoLivros.Application.Livros.Commands.UpdateLivro
{
    public class UpdateLivroCommandHandler : IRequestHandler<UpdateLivroCommand, int>
    {
        private readonly ILivroRepository _LivroRepository;

        public UpdateLivroCommandHandler(ILivroRepository LivroRepository)
        {
            _LivroRepository = LivroRepository;
        }
        public async Task<int> Handle(UpdateLivroCommand request, CancellationToken cancellationToken)
        {
            var UdateLivroEntity = new Livro()
            {
                Id = request.Id,
                 Titulo = request.Titulo,
                 Autor = request.Autor,
                 Editora = request.Editora,
                 Genero = request.Genero,
                 Foto = request.Foto,
                  Ibsn = request.Ibsn,
                 Sinopse = request.Sinopse,
                //ImageUrl = request.ImageUrl,
            };

            return await _LivroRepository.UpdateAsync(request.Id, UdateLivroEntity);
        }
    }
}
