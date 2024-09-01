namespace Vedy.Data
{
    public class Company: BaseEntity
    {
        
        public string CompanyName { get; set; }

        public string Tin { get; set; }
        public virtual List<Customer> Customers { get; set; }
    }
}
