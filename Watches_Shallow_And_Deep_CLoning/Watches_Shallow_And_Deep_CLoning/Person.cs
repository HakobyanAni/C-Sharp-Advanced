using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Watches
{
    public class Person
    {
        public HumanSex Sex { get; set; }

        public Person(HumanSex sex)
        {
            Sex = sex;
        }

        public void WakeUp() // Event subscriber
        {
            Console.WriteLine("Good morning. What time is it?");
        }

        public Person Clone() // Shallow Cloning
        {
            return (Person)this.MemberwiseClone();
        }
    }
}
