namespace Vedy.Data
{
    public class Company: BaseEntity
    {
        public long CustomerId { get; set; } 
        public Customer Customer { get; set; }
        
        public string CompanyName { get; set; }

        public string Tin { get; set; }
    }
}
