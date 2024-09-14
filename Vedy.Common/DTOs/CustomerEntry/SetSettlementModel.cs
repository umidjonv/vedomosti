using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vedy.Common.DTOs.CustomerEntry
{
    public class SetSettlementModel
    {
        public IEnumerable<CustomerEntryModel> Entries { get; set; }
        
        public long SettlementId { get; set; }
    }
}
