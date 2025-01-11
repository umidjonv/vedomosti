using Microsoft.EntityFrameworkCore;
using Vedy.Migrations;

internal class Program
{
    private static void Main(string[] args)
    {
        //if (args.Count() > 0)
        //{
        //    var firstParam = args[0];
        //    switch (firstParam) 
        //    {
        //        case "--apply-migrations":
                    try
                    {
                        // Используем фабрику для создания контекста
                        var factory = new AppDbContextFactory();
                        using var context = factory.CreateDbContext(args);

                        // Применяем миграции
                        Console.WriteLine("Apply migrations...");
                        context.Database.Migrate();

                        Console.WriteLine("Migration complete");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Exception on migration: {ex.Message}");
                    }
        //            break;
        //    }
        //}
    }
}