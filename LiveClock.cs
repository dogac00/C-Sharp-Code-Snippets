using System;

namespace LiveClock
{
    class Program
    {
        static void Main(string[] args)
        {
            Clock.RunSlowClock();
        }
    }

    class Clock
    {
        public static void RunFastClock()
        {
            while (!Console.KeyAvailable)
            {
                DateTime dt = DateTime.Now;
                Console.WriteLine("{0:D2}:{1:D2}:{2:D2}\r", dt.Hour, dt.Minute, dt.Second);
            }
        }

        public static void RunSlowClock()
        {
            DateTime dt1, dt2;

            dt2 = DateTime.Now;

            while (!Console.KeyAvailable)
            {
                dt1 = DateTime.Now;

                if (dt1.Second != dt2.Second)
                    Console.Write("{0:D2}:{1:D2}:{2:D2}\r", dt1.Hour, dt1.Minute, dt1.Second);

                dt2 = dt1;
            }
        }
    }
}
