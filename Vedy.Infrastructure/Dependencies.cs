using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using Vedy.Application.Interfaces;
using Vedy.Infrastructure.Persistence;
using Vedy.Infrastructure.Persistence.Users;
namespace Vedy.Infrastructure
{
    public static class Dependencies
    {

        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration) 
        {
            var section = configuration.GetSection("ConnectionStrings");
            services.AddDbContext<IAppDbContext, AppDbContext>((options) =>
            {
                options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
            });


            services.AddTransient<IUserRepository, UserRepository>();
            return services;
        }

    }
}
