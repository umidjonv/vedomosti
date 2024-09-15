using Vedy.Common;
using Vedy.Consts;
using Vedy.Services.Interfaces;

namespace Vedy.Services
{
    public class ConfigService:IConfigService
    {
        private readonly INetworkClient _networkClient;

        public ConfigService(INetworkClient networkClient)
        {
            _networkClient = networkClient;
        }

        public async Task<AppConfig> GetConfig(CancellationToken cancellationToken)
        {
            var config = await _networkClient.GetRequestAsync<AppConfig>($"{AppConsts.API_URL}config/get", cancellationToken);
            return config;
        }

    }
}
