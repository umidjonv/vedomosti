using Vedy.Common.Enums;

namespace Vedy.Data
{
    public class User : BaseEntity
    {
        public string FullName { get; set; }

        public UserRole Role { get; set; } 

        public virtual IEnumerable<Settlement> Statements { get; set; }
    }
}
