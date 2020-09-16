
using System;
using System.Security.AccessControl;
using System.Threading;

namespace TriangularArbitrage
{
    class Program
    {
        static AutoResetEvent _autoResetEvent = new AutoResetEvent(false);

        static void Main(string[] args)
        {
            Console.WriteLine("Main Thread Started.");

            new Thread(Method).Start();

            Console.ReadLine();

            _autoResetEvent.Set();
        }

        static void Method()
        {
            Console.WriteLine("Another Thread Started.");

            _autoResetEvent.WaitOne();

            Console.WriteLine("Another Thread Continues.");
        }
    }

}
