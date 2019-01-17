using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace GitHubFollowers
{
    public class Repository
    {
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
