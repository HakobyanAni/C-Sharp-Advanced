using System;
using System.Text;

namespace Object_Clone
{
    public class Street
    {
        public string Name { get; set; }

        public Street(string name)
        {
            Name = name;
        }

        public override bool Equals(object obj1)
        {
            if (obj1 is Street)
            {
                return this.Name == (obj1 as Street).Name;
            }
            return false;
        }
    }
}
