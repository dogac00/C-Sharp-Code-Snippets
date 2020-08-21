using System;

namespace KafkaSamples.Extensions
{
    public static class ArrayExtensions
    {
        // Performance is better than Linq
        public static void Reverse<T>(this T[] array)
        {
            for (int i = 0; i < array.Length / 2; i++)
            {
                T tmp = array[i];
                array[i] = array[array.Length - i - 1];
                array[array.Length - i - 1] = tmp;
            }
        }

        public static void Print<T>(this T [] array)
        {
            Console.Write("[");

            for (int i = 0; i < array.Length; i++)
            {
                if (i != 0)
                    Console.Write(", ");

                Console.Write(array[i]);
            }

            Console.Write("]");
        }
    }
}
