using IORoute.Data.Protocols;
using IORoute.Infra.Persistence;
using IORoute.Infra.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace IORoute.Infra
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<RouteContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<RouteContext>();

            services.AddScoped<ILoadRoutesRepository, RoutesRepository>();

            return services;
        }
    }
}
