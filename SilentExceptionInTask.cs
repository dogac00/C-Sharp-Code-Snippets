using System;
using System.Threading.Tasks;

namespace ConsoleAppCs
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting...");

            Task.Factory.StartNew(Action);

            Console.ReadLine();
        }

        private static void Action()
        {
            Console.WriteLine("Throwing Exception...");

            throw new System.NotImplementedException();
        }
    }
}
