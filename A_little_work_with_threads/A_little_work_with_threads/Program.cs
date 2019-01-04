using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Threads
{
    class Program
    {
        static void WriteSentenceFirstPart()
        {
            for (int i = 0; i < 1000; i++)
            {
                Console.WriteLine("Hello ");
                Thread.Sleep(100);  // Sleep() method suspends the current thread for 100 milliseconds.
            }
        }

        static void WriteSentenceSecondPart()
        {
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine("           world !");
                Thread.Sleep(100);
            }
        }

        static void Main(string[] args)
        {
            ThreadStart writeSentence = new ThreadStart(WriteSentenceFirstPart);
            Thread thread = new Thread(writeSentence);
            thread.Start();  // Call of WriteSentenceFirstPart() method in new thread.

            WriteSentenceSecondPart();  // Call of WriteSentenceSecondPart() method in main thread.

            thread.IsBackground = true;  // By giving the true value to IsBackground property we make the main thread not to wait for the secondary
                                         // threads to finish their operation. So the program closes when the main thread finishes it’s operation.
        }
    }
}
