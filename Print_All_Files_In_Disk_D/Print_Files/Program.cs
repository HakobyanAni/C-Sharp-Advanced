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
            Console.WriteLine("These are local disks of your PC");
            string[] drives = Directory.GetLogicalDrives();
            foreach (string drive in drives)
            {
                Console.WriteLine("   - " + drive);
            }
            Console.Write("Select Root : ");
            string root = Console.ReadLine().ToUpper();
            root += ":\\";
            if (drives.Contains(root))
            {
                PrintAllFiles(root);
            }
            else
            {
                Console.WriteLine("Please try again.");
            }
            Console.ReadKey();
        }

        public static void PrintAllFiles(string directoryName)
        {
            string[] allFiles = Directory.GetFiles(directoryName);
            string[] allDirs = Directory.GetDirectories(directoryName);
            try
            {
                foreach (string file in allFiles)
                {
                    Console.WriteLine(file);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            try
            {
                foreach (string dir in allDirs)
                {
                    PrintAllFiles(dir);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
