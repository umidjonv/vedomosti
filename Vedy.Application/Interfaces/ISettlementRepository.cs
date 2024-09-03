using Vedy.Data;

namespace Vedy.Application.Interfaces
{
    public interface ISettlementRepository : IRepository<Settlement>
    {
        public Task<Settlement?> GetById(long id);    
    }
}
