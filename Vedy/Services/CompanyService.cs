using Vedy.Common.DTOs.Company;
using Vedy.Consts;
using Vedy.Models;

namespace Vedy.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly INetworkClient _networkClient;

        public CompanyService(INetworkClient networkClient) 
        {
            _networkClient = networkClient;
        }

        public async Task<CompanyModel> GetCompanyById(int id, CancellationToken cancellationToken)
        {
            var company = await _networkClient.GetRequestAsync<CompanyModel>($"{AppConsts.API_URL}company/get/{id}", cancellationToken);
            return company;
        }

        public Task<CompanyModel> GetCompanyByName(string name, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<List<CompanyModel>?> GetCompanyList(CancellationToken cancellationToken)
        {
            var company = await _networkClient.GetRequestAsync<List<CompanyModel>?>($"{AppConsts.API_URL}company/getall", cancellationToken);
            return company;
        }

        public Task<PaginationModel<CompanyModel>> GetPage(int page, int size, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
