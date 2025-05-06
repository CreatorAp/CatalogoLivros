using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CatalogoLivros.Domain.Entity;

namespace CatalogoLivros.Domain.Repository
{
    public interface IUsuarioRepository
    {
        Task<List<Usuario>> GetAllUsuariosAsync();

        Task<Usuario> GetByIdUsuariosAsync(int id);
        Task<Usuario> CreateAsync(Usuario Usuario);
        Task<int> UpdateAsync(int id, Usuario Usuario);
        Task<int> DeleteAsync(int id);
    }
}
