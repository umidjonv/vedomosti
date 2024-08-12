using Microsoft.EntityFrameworkCore;
using Vedy.Data;

namespace Vedy.Application.Interfaces
{
    public interface IAppDbContext
    {
        DbSet<User> Users { get; }
        DbSet<Customer> Customers { get; }
        DbSet<Statement> Statements { get; }
        DbSet<Company> Companies { get; }

        Task SaveChangesAsync();


        
    }
}
