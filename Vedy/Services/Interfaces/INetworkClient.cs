using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vedy.Services.Interfaces
{
    public interface INetworkClient
    {
        Task<HttpClient> CreateClient();

        Task DestroyClient(HttpClient client);

        Task<TModel> PostRequestAsync<TModel>(string baseUrl, object body, CancellationToken cancellationToken);

        Task<TModel> GetRequestAsync<TModel>(string baseUrl, CancellationToken cancellationToken);

    }
}
