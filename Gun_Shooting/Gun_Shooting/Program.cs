using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gun_Shooting
{
    class Program
    {
        static void Main(string[] args)
        {
            Patron patrons = new Patron(Calipers.Ninemm, 10);
            Gun myGun = new Gun(Types.AK74, patrons);

            Console.WriteLine($"We have a gun and patrons({patrons.Caliper}).");
            Console.WriteLine("Arming the Gun by 10 patrons");
            myGun.ToArm(10);
            Console.WriteLine("Then we shoot all patrons.");
            while (Console.ReadKey().Key == ConsoleKey.Enter)
            {
                if (!myGun.ToShoot(1))
                {
                    Console.WriteLine("There's no patron in the magazine to shoot.");
                    Console.WriteLine();
                }

            Console.WriteLine("Checking if the magazine is empty or not.");
            Console.WriteLine(myGun.IsMagazineEmpty);

            Console.WriteLine("Now emptying the magazine.");
            myGun.ToEmptyMagazine();

            Console.WriteLine("Checking if the magazine is empty or not.");
            Console.WriteLine(myGun.IsMagazineEmpty);

            Console.ReadKey();
        }
    }
}
