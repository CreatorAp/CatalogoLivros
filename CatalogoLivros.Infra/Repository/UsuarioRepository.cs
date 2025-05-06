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
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly CatalogoLivrosDbContext _LivroDbContext;

        public UsuarioRepository(CatalogoLivrosDbContext LivroDbContext)
        {
            _LivroDbContext = LivroDbContext;
        }
        public async Task<Usuario> CreateAsync(Usuario Usuario)
        {
            //Usuario.Foto = "";
            await _LivroDbContext.Usuarios.AddAsync(Usuario);
            await _LivroDbContext.SaveChangesAsync();
            return Usuario;
        }

        public async Task<int> DeleteAsync(int id)
        {
            return await _LivroDbContext.Usuarios
                  .Where(model => model.Id == id)
                  .ExecuteDeleteAsync();
        }

        public async Task<List<Usuario>> GetAllUsuariosAsync()
        {
            return await _LivroDbContext.Usuarios.ToListAsync();
        }

        public async Task<Usuario> GetByIdUsuariosAsync(int id)
        {
            return await _LivroDbContext.Usuarios.AsNoTracking()
                .FirstOrDefaultAsync(b => b.Id == id);
        }



        public async Task<int> UpdateAsync(int id, Usuario Usuario)
        {
            return await _LivroDbContext.Usuarios
                  .Where(model => model.Id == id)
                  .ExecuteUpdateAsync(setters => setters
                    .SetProperty(m => m.Id, Usuario.Id)
                    .SetProperty(m => m.Nome, Usuario.Nome)
                    .SetProperty(m => m.DataNascimento, Usuario.DataNascimento)
                    .SetProperty(m => m.Email, Usuario.Email)
                    .SetProperty(m => m.Senha, Usuario.Senha)

                  );
        }
    }
}
