using System.ComponentModel.DataAnnotations.Schema;

namespace Vedy.Data
{
    [Table("Companies")]

    public class Company: BaseEntity
    {
        
        public string CompanyName { get; set; }

        public string Tin { get; set; }
        public virtual List<CustomerEntry> CustomerEntries { get; set; }
    }
}
