using System;
using System.Threading.Tasks;

namespace ConsoleAppCs
{
    public class Program
    {
        public static void Main(string[] args)
        {
            WillThrow();
        }

        public static void WillThrow()
        {
            FooVoid();

            Console.WriteLine("Here");

            Console.ReadLine();
        }

        public static void WontThrow()
        {
            FooTask();

            Console.WriteLine("Here");

            Console.ReadLine();
        }

        private static async void FooVoid()
        {
            await Task.Yield();

            // This will propagate the exception and will throw in Main
            throw new Exception("My Exception.");
        }

        private static async Task FooTask()
        {
            await Task.Yield();

            // This will NOT propagate the exception and will NOT throw in Main if called like this: FooTask();
            throw new Exception("My Exception.");
        }
    }
}

// Look at this SO response for more information!
// https://stackoverflow.com/questions/5383310/catch-an-exception-thrown-by-an-async-void-method
