namespace Vedy.Data
{
    public class Customer :BaseEntity
    {
        public string FullName { get; set; }
        public string CarNumber { get; set; }

        public string SignHash { get; set; }

        public virtual IEnumerable<Statement> Statements { get; set; }
        public virtual IEnumerable<Company> Companies { get; set; }
    }
}
