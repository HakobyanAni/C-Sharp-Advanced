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
            string[] drives = Directory.GetLogicalDrives();
            Console.Write("Select Root :");
            string root = Console.ReadLine();
            root += ":\\";
            if (drives.Contains(root))
            {
                PrintAllFiles(root);
            }
            else
            {
                Console.WriteLine("Please try again with a capital letter.");
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
