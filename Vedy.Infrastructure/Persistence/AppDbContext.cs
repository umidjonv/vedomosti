
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Vedy.Application.Interfaces;
using Vedy.Data;

namespace Vedy.Infrastructure.Persistence
{
    public class AppDbContext : DbContext, IAppDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
        {

        }

        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasMany(x => x.Statements)
                    .WithOne(x => x.User)
                    .HasForeignKey(x => x.UserId);
                entity.HasQueryFilter(x => x.IsDeleted);
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasMany(x => x.Statements)
                    .WithOne(x => x.Customer)
                    .HasForeignKey(x => x.CustomerId);
                entity.HasQueryFilter(x => x.IsDeleted);
            });

            modelBuilder.Entity<Company>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasOne(x => x.Customer)
                    .WithMany(x => x.Companies)
                    .HasForeignKey(x => x.CustomerId);
                entity.HasQueryFilter(x => x.IsDeleted);
            });
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Statement> Statements { get; set; }

        public DbSet<Company> Companies { get; set; }

        public async Task SaveChangesAsync()
        {
            await base.SaveChangesAsync();
        }
    }
}
