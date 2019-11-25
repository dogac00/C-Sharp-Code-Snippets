using System;

namespace MutableString
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            string s = "I'm immutable, right?";
            
            unsafe
            {
                fixed (char* p = s)
                {
                    *(p + 4) = ' ';
                    *(p + 5) = ' ';
                }
            }

            Console.WriteLine(s); // outputs “I’m   mutable, right?”;
        }
    }
}
