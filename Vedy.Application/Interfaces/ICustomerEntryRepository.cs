using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vedy.Data;

namespace Vedy.Application.Interfaces
{
    public interface ICustomerEntryRepository : IRepository<CustomerEntry>
    {
        public Task<List<CustomerEntry>> GetAll();    
    }
}
