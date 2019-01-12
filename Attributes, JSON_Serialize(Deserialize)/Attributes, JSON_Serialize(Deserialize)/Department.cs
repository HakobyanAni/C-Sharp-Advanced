using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Attribute
{
    public class Department
    {
        public string Name { get; set; }

        [JsonProperty("Department Staff Count")]
        public int StaffCount { get; set; }

        public Department()
        {

        }

        public Department(string name)
        {
            Name = name;
        }

        public Department(string name, int staffCount) : this(name)
        {
            StaffCount = staffCount;
        }
    }
}
