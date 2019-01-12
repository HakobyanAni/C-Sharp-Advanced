using System;
using System.Collections.Generic;
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
