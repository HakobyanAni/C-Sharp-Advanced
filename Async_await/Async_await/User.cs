using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace GitHubFollowers
{
    public class FollowerInfo
    {
        public string URL { get; set; }
    }

    public class User
    {
        [JsonProperty("login")]
        public string UserName { get; set; }

        [JsonProperty("name")]
        public string FullName { get; set; }

        [JsonProperty("id")]
        public int ID { get; set; }

        [JsonProperty("avatar_url")]
        public string Photo { get; set; }

        [JsonProperty("location")]
        public string Country { get; set; }

        [JsonProperty("following")]
        public int Following { get; set; }

        [JsonProperty("followers")]
        public int Followers { get; set; }

        [JsonProperty("followers_url")]
        public string FollowersURL { get; set; }

        [JsonProperty("repos_url")]
        public string RepositoryURL { get; set; }

        public override string ToString()
        {
            return FullName;
        }
    }
}
