using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vedy.Application.Interfaces;
using Vedy.Data;

namespace Vedy.Infrastructure.Persistence.Users
{
    public class UserRepository :GenericRepository<User>,  IUserRepository
    {
        public UserRepository(IAppDbContext context) :base(context) 
        {
        }
        
    }
}
