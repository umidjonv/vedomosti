using Microsoft.EntityFrameworkCore;
using Vedy.Infrastructure.Persistence;

namespace Vedy.Api.DependencyInjection
{
    public static class ConfigureServicesExtension
    {
        public static void AddAutoDbMigrations(this WebApplication webApplication)
        {
            // check if service started for migrations
            if (!Environment.GetCommandLineArgs().Contains("--apply-migrations"))
            {
                Console.WriteLine("Starting as web service, to apply migrations pass: --apply-migrations arg");
                return;
            }

            Console.WriteLine("Starting migrations...");
            try
            {
                using var scope = webApplication.Services.CreateScope();
                var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                dbContext.Database.Migrate();
                Console.WriteLine("Migrations: done!");
                Environment.Exit(0);
            }
            catch (Exception e)
            {
                Console.WriteLine("Failed to apply migrations");
                Console.WriteLine(e);
                Environment.Exit(0);
            }
        }

    }
}