
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
                modelBuilder.Entity<User>().HasData(
                    new User { Id = 1, FullName = "Administrator", Login = "admin", Role = Common.Enums.UserRole.Administrator, Password = "4DA881DECEE92CA3B577F188EAAF92265A5550AF85F391CEB1FBE26A1C72F3E29AF139B1F941CDE4AA64C70CE01BACC3DE4F6F6657BF33CFCAA91EB27CB03EC4" },
                    new User { Id = 2, FullName = "Operator", Login = "operator", Role = Common.Enums.UserRole.Operator, Password = "990B065EF6ECA1303AF386821A61AB374CC412D7C482967086505ACA1295FBF8641DE8F3F0B020E4760A65F55AD7C898351626CDEDF5DAF5683D334B0DC68E2F" }
                );
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
                entity.HasKey(e => e.Id); ;
                entity.HasQueryFilter(x => !x.IsDeleted);
            });


        }

        public DbSet<User> Users { get; set; }

        public DbSet<CustomerEntry> CustomerEntries { get; set; }

        public DbSet<Settlement> Settlements { get; set; }

        public DbSet<Company> Companies { get; set; }

        public async Task SaveChangesAsync()
        {
            HandleSoftDelete();

            await base.SaveChangesAsync();
        }

        private void HandleSoftDelete()
        {
            foreach (var entry in ChangeTracker.Entries().Where(e => e.State == EntityState.Deleted))
            {
                if (entry.Entity is BaseEntity entity)
                {
                    // Mark the entity as modified and set IsDeleted to true
                    entry.State = EntityState.Modified;
                    entity.IsDeleted = true;
                }
            }
        }
    }
}
