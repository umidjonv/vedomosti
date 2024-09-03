using System.ComponentModel.DataAnnotations.Schema;

namespace Vedy.Data
{
    [Table("CustomerEntries")]
    public class CustomerEntry :BaseEntity
    {
        public string FullName { get; set; }
        public string CarNumber { get; set; }

        public string SignHash { get; set; }

        public long Amount { get; set; }
        
        public DateTimeOffset CreatedDate { get; set; }



        public long? CompanyId { get; set; }
        public virtual Company? Company { get; set; }

        public long SettlementId { get; set; }
        public virtual Settlement Settlement { get; set; }
    }
}
