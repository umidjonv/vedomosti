
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Vedy.Infrastructure.Persistence;

namespace Vedy.Migrations
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        private readonly string _connectionString;
        private const string NamespaceName = "Vedy.Migrations";
        private const string Production = "Production";
        public AppDbContextFactory()
        {
            var builder = new ConfigurationBuilder();

            builder.AddEnvironmentVariables();
            var configuration = builder.Build();

            var environment = configuration["DOTNET_ENVIRONMENT"] ?? Production;
            
            if (environment != Production)
            {
                builder.AddJsonFile("appsettings.json", false, true);
                builder.AddEnvironmentVariables();
            }


            _connectionString = configuration["ConnectionStrings:DefaultConnection"];
        }

        public AppDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();

            optionsBuilder.UseNpgsql(_connectionString, b => b.MigrationsAssembly(NamespaceName));

            return new AppDbContext(optionsBuilder.Options);
        }
    }
}
