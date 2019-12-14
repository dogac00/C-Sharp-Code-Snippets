using System;

namespace ExamQuestion
{
    static class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                int i = 5;
                int j = 0;

                int k = i / j;

                Console.WriteLine(k);
            }
            catch (ArithmeticException)
            {
                Console.WriteLine("Arithmetic Exception.");
                goto END;
            }
            finally
            {
                Console.WriteLine("In finally.");
            }

            END:

            Console.WriteLine("Finish.");
        }
    }
}
