using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace Vedy.Common.DTOs.Company
{
    public class CompanyModel
    {
        [JsonProperty("id")]
        
        public long Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("tin")]
        public string Tin { get; set; }
    }
}
