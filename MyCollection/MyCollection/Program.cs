using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCollection
{
    class Program
    {
        static void Main(string[] args)
        {
            // In this task we tried to create our own collection by implementing the IEnumerable and IEnumerator interfaces.
            // The members of these interfaces are not explicitly called, beacause they are implemented to support 
            // the foreach statement to iterate through the collection. 

            MyBookCollection myBooks = new MyBookCollection();

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("         My favorite books\n");

            Console.ForegroundColor = ConsoleColor.DarkGray;
            foreach (Book book in myBooks)
            {
                Console.WriteLine($"'{book.Content}' - {book.Author}");
            }

            Console.ReadKey();
        }
    }
}
