using System;

namespace HalfAdder
{
    class Program
    {
        static void Main(string[] args)
        {
            int r = Add(1, 1);

            Console.WriteLine(r);

            Console.ReadKey();
        }

        static int Add(int x, int y)
        {
            if (y == 0)
                return x;
            if (x == 0)
                return y;

            return Add(x ^ y, (x & y) << 1);
        }

    }
}
