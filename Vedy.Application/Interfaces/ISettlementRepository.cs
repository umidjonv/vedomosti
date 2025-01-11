using Vedy.Data;

namespace Vedy.Application.Interfaces
{
    public interface ISettlementRepository : IRepository<Settlement>
    {
        Task<Settlement?> GetById(long id);

        Task<List<Settlement>> GetAllWithCompany();

        Task DeleteSettlements(long companyId, DateTime startDate, DateTime endDate);
    }
}
