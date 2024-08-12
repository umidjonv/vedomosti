using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vedy.Services
{
    internal interface INetworkClient
    {
        Task<HttpClient> CreateClient();

        Task DestroyClient(HttpClient client);

    }
}
