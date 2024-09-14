using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vedy.Data;

namespace Vedy.Application.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User?> GetByUserName(string username);
    }
}
