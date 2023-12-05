using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using gurusoft_backend.Application.Contracts;
using gurusoft_backend.Infrastructure.Persistence;
using gurusoft_backend.Infrastructure.Repositories;

namespace gurusoft_backend.Infrastructure
{
    public static class InfrastructureServiceRegistratiob
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<NumerosPrimosDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("ConnectionString"))
            );

            services.AddScoped(typeof(IAsyncRepository<>), typeof(RepositoryBase<>));
            services.AddScoped<INumerosPrimosRepository, NumerosPrimosRepository>();


            return services;
        }
    }
}
