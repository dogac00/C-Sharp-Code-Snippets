using System;

namespace ReverseSortArray
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int[] arr = {1, 2, 3, 4, 5, 6};
            
            Array.Sort(arr, Comparison);

            arr.Print();
        }

        private static int Comparison(int x, int y)
        {
            return x <= y ? 1 : -1;
        }
    }

    static class ArrayExtensions
    {
        public static void Print<T>(this T[] array)
        {
            string output = string.Join(", ", array);

            Console.WriteLine(output);
        }
    }
}

