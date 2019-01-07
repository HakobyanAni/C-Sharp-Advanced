using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Watches
{
    class Program
    {
        static void Main(string[] args)
        {
            Person mrStucki = new Person(HumanSex.male);

            Watch watch = new Watch(new MovementType(WatchType.Electronic, Descriptions.Mainspring), Brands.Tissot, Colours.Black, AdditionalFunctions.Smart, 15.5);
            watch.Owner = mrStucki;

            watch.AlarmEvent += mrStucki.WakeUp; // Handling the WakeUp() method to the event AlarmEvent
            watch.OnAlarmEvent(); // Call of the OnAlarmEvent() method(from Watch class)

            Console.WriteLine("--------------------------------------------------------------------------------------------------------------");
            Console.WriteLine(">>>>>>>   SHALLOW CLONING <<<<<<<");

            Watch watchClone1 = watch.WatchClassShallowClone();

            Console.WriteLine("---> Watch price and owner sex, after cloning, for both: original and clone");
            Console.WriteLine($"Watch                 Price - {watch.Price}");
            Console.WriteLine($"WatchShallowClone     Price - {watchClone1.Price}");

            Console.WriteLine($"Watch              OwnerSex - {watch.Owner.Sex}");
            Console.WriteLine($"WatchShallowClone  OwnerSex - {watchClone1.Owner.Sex}");
            Console.WriteLine("---------------------------------");

            mrStucki.Sex = HumanSex.female;
            watch.Price = 333.33;
            Console.WriteLine("---> Watch price and owner sex, after changing original values (Owner sex changes for both as it is ref type)");
            Console.WriteLine($"Watch                 Price - {watch.Price}");
            Console.WriteLine($"WatchShallowClone     Price - {watchClone1.Price}");

            Console.WriteLine($"Watch              OwnerSex - {watch.Owner.Sex}");
            Console.WriteLine($"WatchShallowClone  OwnerSex - {watchClone1.Owner.Sex}");

            Console.WriteLine("----------------------------------------------------------------------------------------------------------------");

            Console.WriteLine(">>>>>>>  DEEP CLONING  <<<<<<");
            Watch watchClone2 = watch.WatchClassDeepClone();

            Console.WriteLine("--->  Watch price and owner sex, after cloning, for both: original and clone");
            Console.WriteLine($"Watch              Price - {watch.Price}");
            Console.WriteLine($"WatchDeepClone     Price - {watchClone2.Price}");

            Console.WriteLine($"Watch           OwnerSex - {watch.Owner.Sex}");
            Console.WriteLine($"WatchDeepClone  OwnerSex - {watchClone2.Owner.Sex}");

            watch.Owner.Sex = HumanSex.male;
            watch.Price = 20;
            Console.WriteLine("---------------------------------");
            Console.WriteLine("---> Watch price and owner sex, after changing original values (Owner sex and price will not change for cloned watch)");
            Console.WriteLine($"Watch                 Price - {watch.Price}");
            Console.WriteLine($"WatchDeepClone        Price - {watchClone2.Price}");

            Console.WriteLine($"Watch              OwnerSex - {watch.Owner.Sex}");
            Console.WriteLine($"WatchDeepClone     OwnerSex - {watchClone2.Owner.Sex}");

            Console.ReadKey();
        }
    }
}
