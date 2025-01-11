using System.Security.Cryptography;
using Vedy.Application.Extensions;
using Vedy.Application.Interfaces;
using Vedy.Common.DTOs.User;
using Vedy.Data;

namespace Vedy.Infrastructure.Services
{
    public class UserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository) 
        {
            this._userRepository = userRepository;
        }

        public async Task<UserResult> AddUser(UserCreate user)
        {
            var entity = await _userRepository.AddAsync(new User 
            {
                FullName = user.FullName,
                Role = user.Role,
                Password = HashingExtension.HashPasword(user.Password),
                Login = user.Login,
            });
            if (entity == null)
            {
                throw new Exception("Users cannot add");
            }

            return new UserResult { Id = entity.Id };
        }

        public async Task<UserResponse> GetUser(long id)
        {
            var entity = await _userRepository.GetByIdAsync(id);
            if (entity == null)
            {
                throw new Exception("Users not found");
            }

            return new UserResponse 
            {
                Id = entity.Id,
                FullName = entity.FullName,
                Role = entity.Role
            };
        }

        public async Task<UserResponse?> Login(LoginModel loginModel)
        {
            var user = await _userRepository.GetByUserName(loginModel.UserName);

            var isLogin = HashingExtension.VerifyPassword(loginModel.Password, user.Password);

            if (isLogin)
            {
                return new UserResponse
                {
                    Id = user.Id,
                    FullName= user.FullName,
                    Role = user.Role,
                    Login = user.Login,
                };
            }

            return null;
        }
    }
}
