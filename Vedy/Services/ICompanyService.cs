using Vedy.Common.DTOs.Company;
using Vedy.Models;

namespace Vedy.Services
{
    public interface ICompanyService
    {
        Task<CompanyModel> GetCompanyById(int id, CancellationToken cancellationToken);

        Task<CompanyModel> GetCompanyByName(string name, CancellationToken cancellationToken);

        Task<PaginationModel<CompanyModel>> GetPage(int page, int size, CancellationToken cancellationToken);
        Task<List<CompanyModel>> GetCompanyList(CancellationToken cancellationToken);

    }
}
