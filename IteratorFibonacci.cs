using System;
using System.Collections.Generic;

namespace IteratorFibonacciApp
{
    class Program
    {
        private static IEnumerable<int> Fibonacci()
        {
            int current = 0;
            int next = 1;

            while (true)
            {
                yield return current;
                int temp = current;
                current = next;
                next += temp;
            }
        }

        public static void Main(string[] args)
        {
            foreach (int num in Fibonacci())
            {
                Console.WriteLine(num);

                if (num > 100000)
                    break;
            }
        }
    }
}
