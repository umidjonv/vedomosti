using Vedy.Common.DTOs.Settlement;
using Vedy.Models;

namespace Vedy.Services.Interfaces
{
    public interface ISettlementService
    {
        Task<SettlementModel> GetById(long id, CancellationToken cancellationToken);

        Task<SettlementModel> GetByName(string name, CancellationToken cancellationToken);

        Task<PaginationModel<SettlementModel>> GetPage(int page, int size, CancellationToken cancellationToken);
        Task<List<SettlementModel>> GetList(CancellationToken cancellationToken);

        Task<SettlementModel> Add(SettlementModel entry, CancellationToken cancellationToken);
        Task<bool> Update(SettlementModel entry, CancellationToken cancellationToken);
        Task<long> Delete(long id, CancellationToken cancellationToken);
    }
}
