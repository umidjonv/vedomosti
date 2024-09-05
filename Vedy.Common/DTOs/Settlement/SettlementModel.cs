
using System.ComponentModel;
using Vedy.Common.DTOs.CustomerEntry;

namespace Vedy.Common.DTOs.Settlement
{
    public class SettlementModel
    {
        [DisplayName("#")]
        public long? Id { get; set; }

        [DisplayName("Номер ведомости")]
        public string Number { get; set; }

        [DisplayName("Дата")]
        public DateTimeOffset Date { get; set; }

        public List<CustomerEntryModel>? CustomerEntries { get; set; }

        public long UserId { get; set; } = 1;
    }
}
