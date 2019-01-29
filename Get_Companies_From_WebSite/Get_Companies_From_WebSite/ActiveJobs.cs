using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Get_Companies_From_WebSite
{
    public class ActiveJobs
    {
        public string JobName { get; set; }
        public string Data { get; set; }
        public string CompanyName { get; set; }
        public string Location { get; set; }

        public ActiveJobs()
        {

        }

        public override string ToString()
        {
            return $"{JobName} \n{Data} \n{Location}";
        }
    }
}
