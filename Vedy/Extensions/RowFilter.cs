using Vedy.Common.DTOs.Company;
using Vedy.Common.DTOs.Settlement;
using Vedy.Models;

namespace Vedy.Extensions
{
    public static class RowFilter
    {
        public static List<CompanyModel> Filter(this List<CompanyModel> list, string searchTerm)
        {
            if (string.IsNullOrEmpty(searchTerm))
            {
                return list;
            }

            return list.Where(x => x.Name.Contains(searchTerm, StringComparison.OrdinalIgnoreCase)
            || x.Tin.Contains(searchTerm, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        public static List<SettlementModel> Filter(this List<SettlementModel> list, string searchTerm)
        {
            if (string.IsNullOrEmpty(searchTerm))
            {
                return list;
            }

            return list.Where(x => x.Date.ToString("d").Contains(searchTerm, StringComparison.OrdinalIgnoreCase)
            || x.CompanyName != null && x.CompanyName.Contains(searchTerm, StringComparison.OrdinalIgnoreCase)).ToList();
        }

    }
}
