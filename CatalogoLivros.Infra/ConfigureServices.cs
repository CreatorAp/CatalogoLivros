using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using CatalogoLivros.Infra.Data;
using CatalogoLivros.Domain.Repository;
using CatalogoLivros.Infra.Repository;

namespace CatalogoLivros.Infra
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddInfraServices(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<CatalogoLivrosDbContext>(options =>
            options.UseSqlite(configuration.GetConnectionString("CatalogoLivrosDbContext") ??
            throw new InvalidOperationException("connection string 'CatalogoLivrosDbContext not found '"))
            );

            services.AddTransient<ILivroRepository, LivroRepository>();
            services.AddTransient<IUsuarioRepository, UsuarioRepository>();

            return services;
        }
    }
}
