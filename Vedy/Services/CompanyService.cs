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
            var company = await _networkClient.GetRequestAsync<CompanyModel>($"/company/get/{id}", cancellationToken);
            return company;
        }

        public Task<CompanyModel> GetCompanyByName(string name, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<PaginationModel<CompanyModel>> GetPage(int page, int size, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
