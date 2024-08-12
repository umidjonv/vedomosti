using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vedy.Application.Interfaces
{
    public interface IRepository<T>
    {
        Task<T?> GetById(long id);
        Task<IEnumerable<T>> GetAll();
        Task Add(T entity);
        Task Update(T entity);
        Task Delete(long id);

    }
}
