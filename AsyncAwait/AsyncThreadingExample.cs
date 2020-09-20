using System;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleAppCs
{
    public static class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Main begins...");

            // In the main thread
            Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
            
            await Foo();
            
            Console.WriteLine("Foo ends...");

            // Continue on the last thread because there is no synchronization context capture
            Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
            
            Console.ReadLine();
        }

        private static async Task Foo()
        {
            // We are still in the main thread here
            Console.WriteLine(Thread.CurrentThread.ManagedThreadId);

            await Task.Yield();

            // Continues on a different thread
            Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
        }
    }
}
