
namespace Vedy.Models
{
    public class Settlement
    {
        public long Id { get; set; }
        public long? CompanyId { get; set; }
        public string SettlementNumber { get; set; }
        public DateTime Date { get; set; }
        public string CustomerName { get; set; }
        public string CarNumber { get; set; }
        public string ImageUrl { get; set; }
    }
}
