using Microsoft.EntityFrameworkCore;
using Vedy.Data;

namespace Vedy.Application.Interfaces
{
    public interface IAppDbContext
    {
        DbSet<User> Users { get; }
        DbSet<CustomerEntry> CustomerEntries { get; }
        DbSet<Settlement> Settlements { get; }
        DbSet<Company> Companies { get; }

        Task SaveChangesAsync();

        DbSet<T> Set<T>() where T : class;


        
    }
}
