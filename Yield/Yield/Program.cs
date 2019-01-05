using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yield
{
    class UserBookCollection
    {
        public static IEnumerable Power()
        {
            yield return "            My Book Collection";
            yield return "'Sherlock Holmes'      -  Arthur Conan-Doil";
            yield return "'To an unknown lady'   -  Andre Maurois";
            yield return "'Les Miserables'       -  Victor Hugo";
            yield return "'The Spy'              -  Fenimore Cooper";
            yield return "'The financier'        -  Theodore Dreiser";
            yield return "'The Genius'           -  Theodore Dreiser";
            yield return "'A Christmas carol'    -  Charles Dickens";
            yield return "'The moon and sixpece' -  William Somerset Maugham";

        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            foreach (string eachBook in UserBookCollection.Power())
            {
                Console.WriteLine(eachBook);
            }
        }
    }
}
