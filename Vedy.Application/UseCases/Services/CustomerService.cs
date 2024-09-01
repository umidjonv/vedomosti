using Vedy.Application.Interfaces;
using Vedy.Common.DTOs.User;
using Vedy.Data;

namespace Vedy.Infrastructure.Services
{
    public class CustomerService
    {
        private readonly IUserRepository _userRepository;

        public CustomerService(IUserRepository userRepository) 
        {
            this._userRepository = userRepository;
        }

        public async Task<UserResult> AddUser(UserCreate user)
        {
            var entity = await _userRepository.AddAsync(new User 
            {
                FullName = user.FullName,
                Role = user.Role
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
    }
}
