
using Vedy.Common.DTOs.CustomerEntry;

namespace Vedy.Common.DTOs.Settlement
{
    public class SettlementModel
    {
        public long? Id { get; set; }

        public string Number { get; set; }

        public DateTimeOffset Date { get; set; }

        public List<CustomerEntryModel>? CustomerEntries { get; set; }

        public long UserId { get; set; } = 1;
    }
}
