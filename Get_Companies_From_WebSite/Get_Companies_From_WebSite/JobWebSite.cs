using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Get_Companies_From_WebSite
{
    public class JobWebSite
    {
        public string Name { get; set; }
        public string URL { get; set; }
        public List<Company> AllCompanies { get; set; }

        public JobWebSite(string name, string url)
        {
            Name = name;
            URL = url;
        }
    }
}
