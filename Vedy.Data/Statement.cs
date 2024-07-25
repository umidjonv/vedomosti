namespace Vedy.Data
{
    public class Statement:BaseEntity
    {
        public long UserId { get; set; }
        public User User { get; set; }

        public long CustomerId { get; set; } 
        public Customer Customer { get; set; }

        public long CompanyId { get; set; }
        public Company Company { get; set; }

        public decimal Amount { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
