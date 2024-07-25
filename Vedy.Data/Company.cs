namespace Vedy.Data
{
    public class Company: BaseEntity
    {
        public long CustomerId { get; set; } 
        public Customer Customer { get; set; }
        
        public virtual List<Statement> Statement { get; set; }
    }
}
