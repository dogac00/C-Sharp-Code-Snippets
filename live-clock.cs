using System;

namespace LiveClock
{
    class Program
    {
        static void Main(string[] args)
        {
            while (!Console.KeyAvailable)
            {
                DateTime dt = DateTime.Now;
                Console.WriteLine("{0:D2}:{1:D2}:{2:D2}\r", dt.Hour, dt.Minute, dt.Second);
            }
        }
    }
}
