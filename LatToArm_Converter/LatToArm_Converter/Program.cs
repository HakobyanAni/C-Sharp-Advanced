using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpProf1
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.Write("Input latin text in armenian :");
            string latinText = Console.ReadLine();
            string armText = latinText.LatToArm();
            Console.WriteLine($"converted: {armText}");
            Console.ReadKey();
        }
    }
}
