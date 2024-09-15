using System.ComponentModel.DataAnnotations.Schema;

namespace Vedy.Data
{
    [Table("Config")]

    public class Config: BaseEntity
    {
        
        public string CompanyName { get; set; }

        public long Tarif { get; set; }
    }
}
