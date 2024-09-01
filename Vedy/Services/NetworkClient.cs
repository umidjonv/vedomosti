using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Vedy.Common.BaseModels;

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
        public async Task<TModel> PostRequestAsync<TModel>(string baseUrl,object body, CancellationToken cancellationToken)
        {
            try
            {
                StringContent jsonContent = new StringContent(JsonConvert.SerializeObject(body), Encoding.UTF8, "application/json");

                var client = await CreateClient();

                var response = await client.PostAsync(new Uri(baseUrl), jsonContent, cancellationToken);


                var responseJson = await response.Content.ReadAsStringAsync(cancellationToken);

                var responseModel = DeserializeResponse<TModel>(responseJson) ?? throw new Exception("esponse body is null");

                return responseModel;
            }
            catch (HttpRequestException ex)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<TModel> GetRequestAsync<TModel>(string baseUrl, CancellationToken cancellationToken)
        {
            try
            {

                var client = await CreateClient();

                var response = await client.GetAsync(new Uri(baseUrl), cancellationToken);

                var responseJson = await response.Content.ReadAsStringAsync(cancellationToken);

                var responseModel = DeserializeResponse<TModel>(responseJson) ?? throw new Exception("response body is null");

                return responseModel;
            }
            catch (HttpRequestException ex)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public T DeserializeResponse<T>(string responseString)
        {
            var responseModel = JsonConvert.DeserializeObject<BaseResponse<T>>(responseString);

            if (responseModel == null || !responseModel.IsSuccess)
            {
                throw new Exception("Cannot parsing returned model");
            }

            return responseModel.Data;
        }

    }
}
