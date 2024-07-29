
using Microsoft.EntityFrameworkCore;
using Vedy.Application.Interfaces;
using Vedy.Data;

namespace Vedy.Infrastructure.Persistence
{
    public class AppDbContext : DbContext, IAppDbContext
    {
        public AppDbContext()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

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

            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasMany(x => x.Statements)
                    .WithOne(x => x.Customer)
                    .HasForeignKey(x => x.CustomerId);
            });

            modelBuilder.Entity<Company>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasOne(x => x.Customer)
                    .WithMany(x => x.Companies)
                    .HasForeignKey(x => x.CustomerId);
            });
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Statement> Statements { get; set; }

        public DbSet<Company> Companies { get; set; }
    }
}
