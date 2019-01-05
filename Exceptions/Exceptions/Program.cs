using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exceptions
{
    public enum Bouquet
    {
        Rose = 1,
        Chamomile,
        Lanterns,
        Violet
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Bouquet> bouquet = new List<Bouquet>();
            bouquet.Add(Bouquet.Rose);
            bouquet.Add(Bouquet.Rose);
            bouquet.Add(Bouquet.Rose);
            bouquet.Add(Bouquet.Rose);
            bouquet.Add(Bouquet.Rose);
            bouquet.Add(Bouquet.Rose);
            bouquet.Add(Bouquet.Rose);

            Console.WriteLine("   We have these kinds of flowers:");
            Console.WriteLine("          Rose      - 1\n          Chamomile - 2\n          Lanterns  - 3\n          Violet    - 4;");
            Console.WriteLine("Select a flower you want:");

            try  // We put the operation into the try block and make it execute in that block 
            {
                string inputFlower = Console.ReadLine();
                int flower = Convert.ToInt32(inputFlower);
                Bouquet selectedFlower = (Bouquet)flower;
                if (bouquet.Contains(selectedFlower))
                {
                    Console.WriteLine($"This {selectedFlower} bouquet is just for you.");
                }
                else
                {
                    Console.WriteLine("I'm sorry. We haven't got that flower.");
                }
            }

            catch (Exception e)
            {
                Console.WriteLine($"Please, insert only numbers! {e.Message}"); // Catch block handles exception thrown by a try block. 
            }

            Console.ReadKey();
        }
    }
}
