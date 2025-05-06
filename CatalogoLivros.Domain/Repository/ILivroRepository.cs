using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CatalogoLivros.Domain.Entity;

namespace CatalogoLivros.Domain.Repository
{
    public interface ILivroRepository
    {
        Task<List<Livro>> GetAllLivrosAsync();

        Task<Livro> GetByIdLivrosAsync(int id);
        Task<Livro> CreateAsync(Livro livro);
        Task<int> UpdateAsync(int id, Livro livro);
        Task<int> DeleteAsync(int id);
    }
}
