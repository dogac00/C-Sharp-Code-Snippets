using System;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            Task task = Method();

            await task;

            Console.ReadLine();
        }

        private static async Task Method()
        {
            await using var fs = new MyObject();
        }
    }

    class MyObject : IAsyncDisposable
    {
        public ValueTask DisposeAsync()
        {
            Console.WriteLine("Disposed Async");

            return new ValueTask(Task.CompletedTask);
        }
    }
}
