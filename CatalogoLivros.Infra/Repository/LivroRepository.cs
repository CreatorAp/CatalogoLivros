using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CatalogoLivros.Domain.Entity;
using CatalogoLivros.Domain.Repository;
using CatalogoLivros.Infra.Data;

namespace CatalogoLivros.Infra.Repository
{
    public class LivroRepository : ILivroRepository
    {
        private readonly CatalogoLivrosDbContext _LivroDbContext;

        public LivroRepository(CatalogoLivrosDbContext LivroDbContext)
        {
            _LivroDbContext = LivroDbContext;
        }
        public async Task<Livro> CreateAsync(Livro Livro)
        {
            Livro.Foto = "";
            await _LivroDbContext.Livros.AddAsync(Livro);
            await _LivroDbContext.SaveChangesAsync();
            return Livro;
        }

        public async Task<int> DeleteAsync(int id)
        {
            return await _LivroDbContext.Livros
                  .Where(model => model.Id == id)
                  .ExecuteDeleteAsync();
        }

        public async Task<List<Livro>> GetAllLivrosAsync()
        {
            return await _LivroDbContext.Livros.ToListAsync();
        }

        public async Task<Livro> GetByIdLivrosAsync(int id)
        {
            return await _LivroDbContext.Livros.AsNoTracking()
                .FirstOrDefaultAsync(b => b.Id == id);
        }



        public async Task<int> UpdateAsync(int id, Livro Livro)
        {
            return await _LivroDbContext.Livros
                  .Where(model => model.Id == id)
                  .ExecuteUpdateAsync(setters => setters
                    .SetProperty(m => m.Id, Livro.Id)
                    .SetProperty(m => m.Titulo, Livro.Titulo)
                    .SetProperty(m => m.Sinopse, Livro.Sinopse)
                    .SetProperty(m => m.Genero, Livro.Genero)
                    .SetProperty(m => m.Ibsn, Livro.Ibsn)
                    .SetProperty(m => m.Foto, Livro.Foto)
                    .SetProperty(m => m.Autor, Livro.Autor)
                    //.SetProperty(m => m.Genero, Livro.Genero)
                  );
        }
    }
}
