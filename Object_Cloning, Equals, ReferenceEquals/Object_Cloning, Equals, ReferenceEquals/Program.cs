using System;
using System.Text;

namespace Object_Clone
{
    class Program
    {
        static void Main(string[] args)
        {
            Street str = new Street("Kievyan");
            House house = new House(str, 5);

            House houseShallowClone = house.ShallowClone();
            House houseDeepClone = house.DeepClone();

            Console.WriteLine("--->    Without changes");
            Console.WriteLine($"house hashcode             - {house.GetHashCode()}       house.Number             - {house.Number}         house.TheStreet.Name              - {house.TheStreet.Name}      street hashcode - {house.TheStreet.GetHashCode()}");
            Console.WriteLine($"houseShallowClone hashcode - {houseShallowClone.GetHashCode()}       houseShallowClone.Number - {houseShallowClone.Number}         houseShallowClone.TheStreet.Name  - {houseShallowClone.TheStreet.Name}      street hashcode - {houseShallowClone.TheStreet.GetHashCode()}");
            Console.WriteLine($"houseDeepClone hashcode    - {houseDeepClone.GetHashCode()}       houseDeepClone.Number    - {houseDeepClone.Number}         houseDeepClone.TheStreet.Name     - {houseDeepClone.TheStreet.Name}      street hashcode - {houseDeepClone.TheStreet.GetHashCode()}");

            Console.WriteLine("");

            house.Number = 10;    // value type
            Console.WriteLine($"house.Number = {house.Number = 10}    // value type");
            house.TheStreet.Name = "Halabyan";   // ref type
            Console.WriteLine($"house.TheStreet.Name = {house.TheStreet.Name = "Halabyan"}    // ref type");
            str.Name = "Nalbandyan";    // ref type
            Console.WriteLine($"str.Name = {str.Name = "Nalbandyan"}    // ref type");

            Console.WriteLine("");
            Console.WriteLine("--->    After changes");
            Console.WriteLine($"house hashcode             - {house.GetHashCode()}      house.Number             - {house.Number}            house.TheStreet.Name              - {house.TheStreet.Name}");
            Console.WriteLine($"houseShallowClone hashcode - {houseShallowClone.GetHashCode()}      houseShallowClone.Number - {houseShallowClone.Number}             houseShallowClone.TheStreet.Name  - {houseShallowClone.TheStreet.Name}");
            Console.WriteLine($"houseDeepClone hashcode    - {houseDeepClone.GetHashCode()}      houseDeepClone.Number    - {houseDeepClone.Number}             houseDeepClone.TheStreet.Name     - {houseDeepClone.TheStreet.Name}");

            house.TheStreet = new Street("Abovyan");
            Console.WriteLine("");
            Console.WriteLine("-------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine($"house.Poxoc = new Street('Abovyan')");

            Console.WriteLine($"house hashcode             - {house.GetHashCode()}      house.Number             - {house.Number}      house.TheStreet.Name             - {house.TheStreet.Name}          street hashcode - {house.TheStreet.GetHashCode()}");
            Console.WriteLine($"houseShallowClone hashcode - {houseShallowClone.GetHashCode()}      houseShallowClone.Number - {houseShallowClone.Number}       houseShallowClone.TheStreet.Name - {houseShallowClone.TheStreet.Name}       street hashcode - {houseShallowClone.TheStreet.GetHashCode()}");
            Console.WriteLine($"houseDeepClone hashcode    - {houseDeepClone.GetHashCode()}      " +
                $"houseDeepClone.Number    - {houseDeepClone.Number}       houseDeepClone.TheStreet.Name    - {houseDeepClone.TheStreet.Name}          street hashcode - {houseDeepClone.TheStreet.GetHashCode()}");

            Console.WriteLine("");
            Console.WriteLine("--->   After change");

            Street str2 = new Street("Nalbandyan");

            Console.WriteLine($"str.Equals(str2)           - {str.Equals(str2)}");
            Console.WriteLine($"ReferenceEquals(str, str2) - {ReferenceEquals(str, str2)}");
            Console.WriteLine($"Equals(str, str2)          - {Equals(str, str2)}");

            Console.ReadKey();
        }
    }
}
