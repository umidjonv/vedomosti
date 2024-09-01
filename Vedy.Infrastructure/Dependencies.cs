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
                options.UseNpgsql("Host=localhost;Database=VedyDb;Username=postgres;Password=123456");
            });


            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<ICompanyRepository, CompanyRepository>();
            services.AddTransient<ICustomerEntryRepository, CustomerEntryRepository>();
            return services;
        }

    }
}
