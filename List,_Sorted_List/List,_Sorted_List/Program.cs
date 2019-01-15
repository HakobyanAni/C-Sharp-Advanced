using System;
using System.Collections.Generic;

namespace List_Sorted_List
{
    class Program
    {
        public static List<int> SortList(List<int> list)
        {
            List<int> newList = new List<int>();
            for (int i = 0; i < list.Count; i++)
            {
                newList.Add(list[i]);
            }
            newList.Sort();
            return newList;
        }

        static void Main(string[] args)
        {
            List<int> list = new List<int>() { 1, 2, 5, 8, 6, 3, 7 };

            // Creating the sorted list of the current list without changing it.

            List<int> sortedList = SortList(list);

            Console.WriteLine("Sorted List");
            for (int i = 0; i < sortedList.Count; i++)
            {
                Console.Write(sortedList[i] + " ");
            }

            Console.WriteLine(" ");
            Console.WriteLine("List");
            for (int i = 0; i < list.Count; i++)
            {
                Console.Write(list[i] + " ");
            }

            Console.ReadKey();
        }
    }
}
