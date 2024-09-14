using Microsoft.EntityFrameworkCore;
using Vedy.Application.Interfaces;
using Vedy.Data;

namespace Vedy.Infrastructure.Persistence.Users
{
    public class UserRepository :GenericRepository<User>,  IUserRepository
    {
        public UserRepository(IAppDbContext context) :base(context) 
        {
        }

        public Task<User?> GetByUserName(string username)
        {
            return context.Users.FirstOrDefaultAsync(x => x.Login == username);
        }

    }
}
