using System.ComponentModel.DataAnnotations.Schema;

namespace Vedy.Data
{
    [Table("Settlements")]
    public class Settlement : BaseEntity
    {
        public long UserId { get; set; }
        public User User { get; set; }

        public string Number { get; set; }
        public DateTimeOffset Date { get; set; }

        public virtual List<CustomerEntry> CustomerEntries { get; set; }
    }
}
