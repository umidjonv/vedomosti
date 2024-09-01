namespace Vedy.Data
{
    public class CustomerEntry :BaseEntity
    {
        public string FullName { get; set; }
        public string CarNumber { get; set; }

        public string SignHash { get; set; }

        public decimal Amount { get; set; }
        
        public DateTime CreatedDate { get; set; }

        public long? CompanyId { get; set; }
        public virtual Company? Company { get; set; }

        public long SettlementId { get; set; }
        public virtual Settlement Settlement { get; set; }
    }
}
