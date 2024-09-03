using Vedy.Common.Enums;

namespace Vedy.Data
{
    public class User : BaseEntity
    {
        public string FullName { get; set; }

        public UserRole Role { get; set; } 

        public string Login {  get; set; }

        public string Password { get; set; }

        public virtual IEnumerable<Statement> Statements { get; set; }
    }
}
