using Vedy.Common.Enums;

namespace Vedy.Common.DTOs.User
{
    public class UserResponse
    {
        public long Id { get; set; }

        public string FullName { get; set; }

        public UserRole Role { get; set; }

        public string Login {  get; set; }
    }
}
