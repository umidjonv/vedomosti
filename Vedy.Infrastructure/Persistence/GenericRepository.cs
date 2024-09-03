using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vedy.Application.Interfaces;
using Vedy.Data;

namespace Vedy.Infrastructure.Persistence
{
    public class GenericRepository<TEntity>(IAppDbContext context) where TEntity : BaseEntity
    {
        internal readonly IAppDbContext context = context;

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            context.Set<TEntity>().Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(long id)
        {
            var entity = context.Set<TEntity>().FirstOrDefault(x=>x.Id == id);
            if (entity != null)
            {
                entity.IsDeleted = true;
            }
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return context.Set<TEntity>().AsEnumerable();
        }

        public async Task<TEntity?> GetByIdAsync(long id)
        {
            return context.Set<TEntity>().FirstOrDefault(x => x.Id == id);
        }

        public async Task UpdateAsync(TEntity entity)
        {
            context.Set<TEntity>().Update(entity);
            await context.SaveChangesAsync();
        }
    }
}
