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

                    throw new NotImplementedException();
                });
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            Console.WriteLine("End...");

            Console.Read();
        }

        private static async Task Foo(Func<Task> func)
        {
            await func();
        }
    }
}
