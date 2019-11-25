using System;
using System.Reflection;

namespace NotReallyReadonly
{
    class Program
    {
        private static readonly int x = 1234;

        public static void Main(string[] args)
        {
            typeof(Program)
                .GetField("x", BindingFlags.NonPublic | BindingFlags.Static)
                ?.SetValue(null, 5678);

            Console.WriteLine(x);
        }
    }
}
