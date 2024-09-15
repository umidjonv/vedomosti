using Vedy.Common.DTOs.User;

namespace Vedy.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserResponse?> Login(string username, string password, CancellationToken token);
    }
}
