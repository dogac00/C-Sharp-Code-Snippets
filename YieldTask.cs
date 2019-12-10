using System;
using System.Threading;
using System.Threading.Tasks;

namespace YieldTaskApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            System.Console.WriteLine("Before task: " + Thread.CurrentThread.ManagedThreadId);

            Task task = Method();

            System.Console.WriteLine("After task: " + Thread.CurrentThread.ManagedThreadId);

            System.Console.ReadLine();
        }

        private static async Task Method()
        {
            System.Console.WriteLine("Before yield : " + Thread.CurrentThread.ManagedThreadId);

            await Task.Yield();

            System.Console.WriteLine("After yield : " + Thread.CurrentThread.ManagedThreadId);
        }
     }
}
