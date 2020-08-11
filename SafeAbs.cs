using System;

namespace ConsoleAppCs
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(SafeAbs(int.MinValue));
        }

        static int SafeAbs(int value)
        {
            return value == int.MinValue ? int.MaxValue : Math.Abs(value);
        }
    }
}
