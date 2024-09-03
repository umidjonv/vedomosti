using Microsoft.EntityFrameworkCore;
using Vedy.Application.Interfaces;
using Vedy.Data;

namespace Vedy.Infrastructure.Persistence.Settlements
{
    public class SettlementRepository : GenericRepository<Settlement>, ISettlementRepository
    {
        public SettlementRepository(IAppDbContext context) : base(context)
        {
        }

        public Task<Settlement?> GetById(long id)
        {
            return context.Set<Settlement>()
                .Include(x => x.CustomerEntries)
                .ThenInclude(x => x.Company)
                .FirstOrDefaultAsync(x=>x.Id == id);
        }
    }
}
