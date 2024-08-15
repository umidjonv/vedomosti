using Vedy.Common.Enums;

namespace Vedy.Common.DTOs.Company
{
    public class CustomerCreate
    {
        public string FullName { get; set; }

        public UserRole Role { get; set; }
    }
}
