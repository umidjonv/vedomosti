using System.Threading;
using Vedy.Common.DTOs.Company;
using Vedy.Common.DTOs.CustomerEntry;
using Vedy.Consts;
using Vedy.Models;

namespace Vedy.Services
{
    public class CustomerEntryService : ICustomerEntryService
    {
        private readonly INetworkClient _networkClient;

        public CustomerEntryService(INetworkClient networkClient) 
        {
            _networkClient = networkClient;
        }

        public async Task<CustomerEntryModel> Add(CustomerEntryModel company, CancellationToken cancellationToken)
        {
            var result = await _networkClient.PostRequestAsync<CustomerEntryModel>($"{AppConsts.API_URL}customerentry/add", company, cancellationToken);
            return result;
        }
        public async Task<bool> Update(CustomerEntryModel company, CancellationToken cancellationToken)
        {
            var result = await _networkClient.PostRequestAsync<bool>($"{AppConsts.API_URL}customerentry/update", company, cancellationToken);
            return result;
        }

        public async Task<long> Delete(long id, CancellationToken cancellationToken)
        {
            var result = await _networkClient.GetRequestAsync<long>($"{AppConsts.API_URL}customerentry/delete/{id}", cancellationToken);
            return result;
        }

        public async Task<CustomerEntryModel> GetById(int id, CancellationToken cancellationToken)
        {
            var company = await _networkClient.GetRequestAsync<CustomerEntryModel>($"{AppConsts.API_URL}customerentry/get/{id}", cancellationToken);
            return company;
        }

        public Task<CustomerEntryModel> GetByName(string name, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<List<CustomerEntryModel>?> GetList(CancellationToken cancellationToken)
        {
            var company = await _networkClient.GetRequestAsync<List<CustomerEntryModel>?>($"{AppConsts.API_URL}customerentry/getall", cancellationToken);
            return company;
        }

        public Task<PaginationModel<CustomerEntryModel>> GetPage(int page, int size, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

    }
}
