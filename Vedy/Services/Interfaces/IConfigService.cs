using Vedy.Common;

namespace Vedy.Services.Interfaces
{
    public interface IConfigService
    {
        Task<AppConfig> GetConfig(CancellationToken cancellationToken);
    }
}
