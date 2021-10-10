using Catalogo.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Catalogo.Applictation.Mappings;
using Catalogo.Domain.Interfaces;
using Catalogo.Infrastructure.Repositories;
using Catalogo.Applictation.Interfaces;
using Catalogo.Applictation.Services;

namespace Catalogo.CrossCutting.IoC
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration cofiguration)
        {
            services.AddDbContext<MeuDbContext>
                (o => o.UseSqlServer(cofiguration.GetConnectionString("DefaultConnection")));


            services.AddScoped<ICategoriaRepository, CategoriaRepository>();
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<IProdutoService, ProdutoService>();
            services.AddScoped<ICategoriaService, CategoriaService>();

            services.AddAutoMapper(typeof(DomainToDTOMappingProfile));
            return services;
        }
    }
}
