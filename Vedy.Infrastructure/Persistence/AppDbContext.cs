
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
                entity.HasMany(x => x.Settlements)
                    .WithOne(x => x.User)
                    .HasForeignKey(x => x.UserId);
                entity.HasQueryFilter(x => !x.IsDeleted);
            });

            modelBuilder.Entity<Settlement>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasQueryFilter(x => !x.IsDeleted);
            });

            modelBuilder.Entity<CustomerEntry>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasOne(x => x.Settlement)
                    .WithMany(x => x.CustomerEntries)
                    .HasForeignKey(x => x.SettlementId);

                entity.HasOne(x => x.Company)
                    .WithMany(x => x.CustomerEntries)
                    .HasForeignKey(x => x.CompanyId);

                entity.HasOne(x => x.Settlement)
                    .WithMany(x => x.CustomerEntries)
                    .HasForeignKey(x => x.SettlementId);


                entity.HasQueryFilter(x => !x.IsDeleted);
            });

            modelBuilder.Entity<Company>(entity =>
            {
                entity.HasKey(e => e.Id);;
                entity.HasQueryFilter(x => !x.IsDeleted);
            });

            
        }

        public DbSet<User> Users { get; set; }

        public DbSet<CustomerEntry> CustomerEntries { get; set; }

        public DbSet<Settlement> Settlements { get; set; }

        public DbSet<Company> Companies { get; set; }

        public async Task SaveChangesAsync()
        {
            await base.SaveChangesAsync();
        }
    }
}
