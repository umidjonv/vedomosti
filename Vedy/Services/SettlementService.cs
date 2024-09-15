using Vedy.Common.DTOs.Settlement;
using Vedy.Consts;
using Vedy.Models;
using Vedy.Services.Interfaces;

namespace Vedy.Services
{
    public class SettlementService : ISettlementService
    {
        private readonly INetworkClient _networkClient;

        public SettlementService(INetworkClient networkClient) 
        {
            _networkClient = networkClient;
        }

        public async Task<SettlementModel> Add(SettlementModel company, CancellationToken cancellationToken)
        {
            var result = await _networkClient.PostRequestAsync<SettlementModel>($"{AppConsts.API_URL}settlement/add", company, cancellationToken);
            return result;
        }
        public async Task<bool> Update(SettlementModel company, CancellationToken cancellationToken)
        {
            var result = await _networkClient.PostRequestAsync<bool>($"{AppConsts.API_URL}settlement/update", company, cancellationToken);
            return result;
        }

        public async Task<long> Delete(long id, CancellationToken cancellationToken)
        {
            var result = await _networkClient.GetRequestAsync<long>($"{AppConsts.API_URL}settlement/delete/{id}", cancellationToken);
            return result;
        }

        public async Task<SettlementModel?> GetById(long id, CancellationToken cancellationToken)
        {
            var company = await _networkClient.GetRequestAsync<SettlementModel?>($"{AppConsts.API_URL}settlement/get/{id}", cancellationToken);
            return company;
        }

        public Task<SettlementModel> GetByName(string name, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<List<SettlementModel>?> GetList(CancellationToken cancellationToken)
        {
            var company = await _networkClient.GetRequestAsync<List<SettlementModel>?>($"{AppConsts.API_URL}settlement/getall", cancellationToken);
            return company;
        }

        public Task<PaginationModel<SettlementModel>> GetPage(int page, int size, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

    }
}
