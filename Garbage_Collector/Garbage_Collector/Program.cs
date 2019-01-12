using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarbageCollector
{
    class TestClassForGC
    {
        ~TestClassForGC()
        {
            for (int i = 0; i < 50; i++)
            {
                Console.Write("1");
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"Memory without GC - {GC.GetTotalMemory(false) / 1024} kb"); // without GC
            Console.WriteLine("");

            long[] a = new long[1024 * 5]; // about 40kb

            // array a is in 0 Generation
            Console.WriteLine($"Generation - {GC.GetGeneration(a)}");
            Console.WriteLine($"Memory without GC - {GC.GetTotalMemory(false) / 1024} kb"); // without GC
            Console.WriteLine("");

            byte[] b = new byte[1024 * 1024 * 100]; // about 819kb

            // array b is in 2 Generation
            Console.WriteLine($"Generation - {GC.GetGeneration(b)}");
            Console.WriteLine($"Memory without GC - {GC.GetTotalMemory(false) / 1024} kb"); //without GC

            Console.WriteLine($"Memory with GC - {GC.GetTotalMemory(true) / 1024} kb");
            Console.WriteLine("");

            string s = "abcdefghijkl";
            Console.WriteLine($"Memory without GC - {GC.GetTotalMemory(false) / 1024} kb"); //without GC
            string t = s + "1234567890";
            Console.WriteLine($"Memory without GC - {GC.GetTotalMemory(false) / 1024} kb"); //without GC
            t = null;
            Console.WriteLine($"Memory without GC - {GC.GetTotalMemory(false) / 1024} kb"); //without GC
            Console.WriteLine("");

            TestClassForGC forGBCollector = new TestClassForGC();

            for (int i = 0; i < 100; i++)
            {
                Console.Write("0");
            }

            GC.Collect();

            // Makes the program to wait for the GB Collector finalization
            GC.WaitForPendingFinalizers();

            Console.ReadKey();
        }
    }
}
