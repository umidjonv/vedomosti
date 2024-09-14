using Vedy.Common.DTOs.Company;

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

    }
}
