using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using CatalogoLivros.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace CatalogoLivros.Infra.Data
{
    public class CatalogoLivrosDbContext : DbContext
    {
        public CatalogoLivrosDbContext(DbContextOptions<CatalogoLivrosDbContext> dbContextOptions)
            : base(dbContextOptions)
        {
        }

        public DbSet<Livro> Livros { get; set; }

        public DbSet<Usuario> Usuarios { get; set; }
    }
}
