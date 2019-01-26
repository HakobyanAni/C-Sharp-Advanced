using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IT_Companies_JSON_
{
    public class ITCompany
    {
        [JsonProperty("name")]
        public string CompanyName { get; set; }

        [JsonProperty("_id")]
        public string ID { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonIgnore]
        public string logo { get; set; }

        [JsonProperty("about")]
        public string AboutCompany { get; set; }

        [JsonIgnore]
        public string Created { get; set; }

        [JsonProperty("photos")]
        public List<string> Photos { get; set; }

        [JsonProperty("rating")]
        public int Rating { get; set; }

        [JsonProperty("billingPlan")]
        public string billingPlan { get; set; }

        [JsonProperty("id")]
        public string _ID { get; set; }
    }
}
