namespace Vedy.Data
{
    public class Settlement : BaseEntity
    {
        public long UserId { get; set; }
        public User User { get; set; }

        public string Number { get; set; }
        public DateTime Date { get; set; }

        public virtual List<CustomerEntry> CustomerEntries { get; set; }
    }
}
