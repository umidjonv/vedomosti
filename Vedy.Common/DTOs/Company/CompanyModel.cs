using Newtonsoft.Json;
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace Vedy.Common.DTOs.Company
{
    public class CompanyModel
    {
        [DisplayName("#")]
        [JsonProperty("id")]
        public long Id { get; set; }
        
        [DisplayName("Наименование")]
        [JsonProperty("name")]
        public string Name { get; set; }

        [DisplayName("ИНН")]
        [JsonProperty("tin")]
        public string Tin { get; set; }
    }
}
