using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vedy.Common.DTOs.CustomerEntry
{
    public class CustomerEntryModel
    {

        //[DisplayName("#")]
        public long? Id { get; set; }
        [DisplayName("ФИО")]
        public string FullName { get; set; }
        [DisplayName("Номер машины")]
        public string CarNumber { get; set; }
        public string SignHash { get; set; }
        [DisplayName("Куб")]
        public long Amount { get; set; }

        [DisplayName("Сумма")]
        public long Sum { get; set; }
        [DisplayName("Дата")]
        public DateTime CreatedDate { get; set; }
        public long? CompanyId { get; set; }
        [DisplayName("Компания")]
        public string? CompanyName { get; set; }

        public long? SettlementId { get; set; }
        [DisplayName("Ведомость")]
        public string? SettlementNumber { get; set; }
        public DateTime? SettlementDate { get; set; }

    }
}
