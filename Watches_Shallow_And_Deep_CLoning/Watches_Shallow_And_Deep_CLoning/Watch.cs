using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Watches
{
    public class Watch
    {
        public Person Owner { get; set; } //  ref type
        public MovementType TypeM { get; set; } // value type
        public Brands Brand { get; set; } // value type
        public Colours Colour { get; set; } // value type
        public AdditionalFunctions AdditionalFunction { get; set; } // value type
        public double Price { get; set; } // value type 

        public event AlarmClockDelegate AlarmEvent;

        public Watch(Person owner, MovementType type, Brands brand, Colours colour, AdditionalFunctions additionalFunction, double price)
        {
            Owner = owner;
            TypeM = type;
            Brand = brand;
            Colour = colour;
            AdditionalFunction = additionalFunction;
            Price = price;
        }

        public Watch(MovementType type, Brands brand, Colours colour, AdditionalFunctions additionalFunction, double price)
        {
            TypeM = type;
            Brand = brand;
            Colour = colour;
            AdditionalFunction = additionalFunction;
            Price = price;
        }

        public void OnAlarmEvent() // Event handler
        {
            if (AlarmEvent != null)
            {
                AlarmEvent.Invoke();
            }
        }

        public Watch WatchClassShallowClone()  // Shallow Cloning
        {
            return (Watch)this.MemberwiseClone();
            // Another way to create shallow clone
            // return new Watch(this.Owner, this.Type, this.Brand,this.Colour, this.AdditionalFunction);
        }

        public Watch WatchClassDeepClone()  // Deep Cloning
        {
            return new Watch(this.Owner.Clone(), this.TypeM, this.Brand, this.Colour, this.AdditionalFunction, this.Price);
        }
    }
}
