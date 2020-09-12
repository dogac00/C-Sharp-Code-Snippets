using System;
using System.Threading.Tasks;

namespace ConsoleAppCs
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            try
            {
                await Foo(async () => 
                {
                    await Task.Yield();

                    throw new NotImplementedException(); // This will raise an unhandled exception
                });
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            Console.WriteLine("End...");

            Console.Read();
        }

        private static async Task Foo(Action func)
        {
            func();
        }
    }
}
