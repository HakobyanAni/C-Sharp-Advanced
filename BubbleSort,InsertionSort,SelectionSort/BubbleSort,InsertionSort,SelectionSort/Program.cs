using System;

namespace Sorting
{
    class Program
    {
        public static void SelectionSort(int[] array)  // O(n^2)
        {
            for (int i = 0; i < array.Length - 1; i++) // O(n)
            {
                int minIndex = i;  // O(1)
                for (int j = i + 1; j < array.Length; j++) // O(n)
                {
                    if (array[j] < array[minIndex])
                    {
                        minIndex = j;  // O(1)
                    }
                }
                int temp = array[minIndex]; // O(1)
                array[minIndex] = array[i];  // O(1) 
                array[i] = temp;  // O(1)
            }
        }

        public static void InsertionSort(int[] array)  // O(n^2)
        {
            for (int i = 1; i < array.Length; i++) // O(n)
            {
                int key = array[i];   // O(1)
                int j = i - 1;   // O(1)
                while (j >= 0 && array[j] > key) // O(n)
                {
                    array[j + 1] = array[j]; // O(1)
                    j -= 1;   // O(1)
                }
                array[j + 1] = key;   // O(1)
            }
        }

        public static void BubbleSort(ref int[] array)  // O(n^2)
        {
            for (int i = 0; i < array.Length - 1; i++) // O(n)
            {
                for (int j = 0; j < array.Length - 1 - i; j++)  // O(n)
                {
                    if (array[j] > array[j + 1])
                    {
                        int temp = array[j];       // O(1)
                        array[j] = array[j + 1];   // O(1)
                        array[j + 1] = temp;       // O(1)

                    }
                }
            }
        }

        public static void Print(int[] array)  // O(n)
        {
            foreach (var item in array)  // O(n)
            {
                Console.Write(item + " ");  // O(1) 
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
            Console.WriteLine(" -> My array");
            int[] array1 = GetRandomIntArray(10);
            Print(array1);
            Console.WriteLine();

            Console.WriteLine(" -> After Bubble Sort");
            BubbleSort(ref array1);
            Print(array1);
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine(" -> My new array");
            int[] array2 = GetRandomIntArray(9);
            Print(array2);
            Console.WriteLine();

            Console.WriteLine(" -> After Insertion Sort");
            InsertionSort(array2);
            Print(array2);
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine(" -> My new array");
            int[] array3 = GetRandomIntArray(8);
            Print(array3);
            Console.WriteLine();

            Console.WriteLine(" -> After Selection Sort");
            SelectionSort(array3);
            Print(array3);
            Console.WriteLine();

            Console.ReadKey();
        }
    }
}
