using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vedy.Common.DTOs.CustomerEntry
{
    public class CustomerEntryModel
    {

        public long? Id { get; set; }
        public string FullName { get; set; }
        public string CarNumber { get; set; }

        public string SignHash { get; set; }

        public long Amount { get; set; }

        public DateTimeOffset CreatedDate { get; set; }

        public long? CompanyId { get; set; }
        public string? CompanyName { get; set; }

        public long SettlementId { get; set; }
        public string SettlementNumber { get; set; }
        public DateTimeOffset SettlementDate { get; set; }

    }
}
