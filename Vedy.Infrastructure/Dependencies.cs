using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using Vedy.Application.Interfaces;
using Vedy.Infrastructure.Persistence;
using Vedy.Infrastructure.Persistence.Settlements;
using Vedy.Infrastructure.Persistence.Users;
namespace Vedy.Infrastructure
{
    public static class Dependencies
    {

        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration) 
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", false);
            var section = configuration.GetSection("ConnectionStrings");
            services.AddDbContext<IAppDbContext, AppDbContext>((options) =>
            {
                options.UseNpgsql(section.GetSection("DefaultConnection").Value);
            });


            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<ICompanyRepository, CompanyRepository>();
            services.AddTransient<ICustomerEntryRepository, CustomerEntryRepository>();
            services.AddTransient<ISettlementRepository, SettlementRepository>();

            return services;
        }

    }
}
