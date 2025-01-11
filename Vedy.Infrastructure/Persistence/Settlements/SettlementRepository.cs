using Microsoft.EntityFrameworkCore;
using Vedy.Application.Interfaces;
using Vedy.Data;
using static iText.StyledXmlParser.Jsoup.Select.Evaluator;

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
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public Task<List<Settlement>> GetAllWithCompany()
        {
            return context.Set<Settlement>()
                .Include(x => x.Company)
                .ToListAsync();
        }

        public async Task DeleteSettlements(long companyId, DateTime startDate, DateTime endDate)
        {
            var settlements = context.Set<Settlement>()
                .Where(x => x.StartDate.Equals(startDate) && x.EndDate.Equals(endDate) && x.CompanyId == companyId)
                .ToList();
            foreach (var item in settlements) 
            {
                context.Settlements.Remove(item);
                
            }

            await context.SaveChangesAsync();
        }
    }
}
