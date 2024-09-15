using Vedy.Common.DTOs.User;
using Vedy.Consts;
using Vedy.Services.Interfaces;

namespace Vedy.Services
{
    public class UserService:IUserService
    {
        private readonly INetworkClient _networkClient;

        public UserService(INetworkClient networkClient)
        {
            this._networkClient = networkClient;
        }

        public async Task<UserResponse?> Login(string username, string password, CancellationToken token)
        { 
            return await _networkClient.PostRequestAsync<UserResponse>($"{AppConsts.API_URL}user/login", new LoginModel { UserName = username, Password = password }, token);

        }
    }
}
