using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using Vedy.Application.Interfaces;
using Vedy.Infrastructure.Persistence;
namespace Vedy.Infrastructure
{
    public static class Dependencies
    {

        public static IServiceCollection AddDependencies(this IServiceCollection services, IConfiguration configuration) 
        {
            services.AddDbContext<IAppDbContext, AppDbContext>((options) =>
            {
                options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
            });

            return services;
        }

    }
}
