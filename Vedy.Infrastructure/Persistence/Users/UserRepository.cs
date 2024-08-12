using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vedy.Application.Interfaces;
using Vedy.Data;

namespace Vedy.Infrastructure.Persistence.Users
{
    public class UserRepository(IAppDbContext context) : IRepository<User>
    {
        public async Task Add(User entity)
        {
            context.Users.Add(entity);
            await context.SaveChangesAsync();
        }

        public Task Delete(long id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            return context.Users.AsEnumerable();
        }

        public async Task<User?> GetById(long id)
        {
            return context.Users.FirstOrDefault(x => x.Id == id);
        }

        public async Task Update(User entity)
        {
            context.Users.Update(entity);
            await context.SaveChangesAsync();
        }
    }
}
