using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Binary_search
{
    class Program
    {
        static bool BinarySearch(int[] myArray, int firstIndex, int lastIndex, int element)
        {
            if (firstIndex == lastIndex && myArray[firstIndex] != element)
            {
                return false;
            }

            int middleElIndex = (lastIndex + firstIndex) / 2;

            if (element == myArray[middleElIndex])
            {
                return true;
            }

            if(element > myArray[middleElIndex])
            {
                return BinarySearch(myArray, middleElIndex + 1, lastIndex, element);
            }
            else
            {
                return BinarySearch(myArray, firstIndex, middleElIndex - 1, element);
            }
        }

        public static int[] GetRandomIntArray(int arrayLength)
        {
            int[] array = new int[arrayLength];
            Random random = new Random();
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(0, arrayLength);
            }
            return array;
        }

        static void Main(string[] args)
        {
            Console.Write("Please write some length of array to start generate that array randomly: ");
            string number = Console.ReadLine();
            int arrayLength = Convert.ToInt32(number);

            int[] array = GetRandomIntArray(arrayLength);

            Console.Write("Write a number to check exists it in array or not: ");
            string key = Console.ReadLine();
            int findKey = Convert.ToInt32(key);

            Console.WriteLine("Here is the randomly generated array.");
            Console.WriteLine(BinarySearch( array, 0, array.Length - 1, findKey));
            foreach (var el in array)
            {
                Console.Write(el + " ");
            }

            Console.ReadKey();
        }
    }
}
