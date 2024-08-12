using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vedy.Services
{
    public class NetworkClient : IDisposable, INetworkClient
    {
        public NetworkClient() { }
        private List<HttpClient> httpClients = new List<HttpClient>();


        public async Task<HttpClient> CreateClient()
        {
            var client = new HttpClient();
            httpClients.Add(client);
            return client;
        }

        public async Task DestroyClient(HttpClient client)
        {
            var found = httpClients.Find(x => x == client);
            if (found != null) 
            {
                found.CancelPendingRequests();
            }
            client.Dispose();
        }

        public void Dispose()
        {
            
        }
    }
}
