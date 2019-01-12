using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Object_Clone
{
    public class House
    {
        public Street TheStreet { get; set; }
        public int Number { get; set; }

        public House(Street theStreet, int number)
        {
            TheStreet = theStreet;
            Number = number;
        }

        public House ShallowClone()
        {
            return new House(this.TheStreet, this.Number);
        }

        public House DeepClone()
        {
            return new House(new Street(this.TheStreet.Name), this.Number);
        }
    }
}
