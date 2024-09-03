using System.ComponentModel.DataAnnotations.Schema;
using Vedy.Common.Enums;

namespace Vedy.Data
{
 
    [Table("Users")]
    public class User : BaseEntity
    {
        public string FullName { get; set; }

        public UserRole Role { get; set; } 

        public virtual IEnumerable<Settlement> Settlements { get; set; }
        public string Login {  get; set; }

        public string Password { get; set; }

    }
}
