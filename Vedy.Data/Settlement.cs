using System.ComponentModel.DataAnnotations.Schema;

namespace Vedy.Data
{
    [Table("Settlements")]
    public class Settlement : BaseEntity
    {
        public long UserId { get; set; }
        public User User { get; set; }

        public string Number { get; set; }

        [Column(TypeName = "timestamp without time zone")]
        public DateTime Date { get; set; }

        public long? CompanyId { get; set; }
        public Company? Company { get; set; }

        public virtual List<CustomerEntry> CustomerEntries { get; set; }
    }
}
