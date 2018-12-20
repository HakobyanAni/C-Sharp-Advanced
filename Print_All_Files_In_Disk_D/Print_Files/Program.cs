using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Print_Files
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Select Root :");
            string root = Console.ReadLine(); 
            switch (root)
            {
                case "D":
                    PrintAllFiles(@"D:\");
                    break;
                case "C":
                    PrintAllFiles(@"C:\");
                    break;
                default:
                    Console.WriteLine("Please select D or C");
                    break;
            }
            Console.ReadKey();
        }

        public static void PrintAllFiles(string directoryName)
        {
            string[] allFiles = Directory.GetFiles(directoryName);
            string[] allDirs = Directory.GetDirectories(directoryName);
            
            foreach (string file in allFiles)  
            {
                Console.WriteLine(file);
            }
            foreach (string dir in allDirs)
            {
                PrintAllFiles(dir); 
            }
        }
    }
}
