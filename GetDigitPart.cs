using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GetDigitPartBenchmarking
{
    class Program
    {
        private static string[] inputs = new string[1000];

        static void Main(string[] args)
        {
            for (int i = 0; i < 1000; i++)
            {
                inputs[i] = GetRandomString();
            }

            Stopwatch stopwatch = Stopwatch.StartNew();

            for (int j = 0; j < 10000; j++)
            {
                for (int i = 0; i < 1000; i++)
                {
                    int digitPart = GetDigitPart1(inputs[i]);
                }
            }

            Console.WriteLine(stopwatch.ElapsedMilliseconds);

            Console.Read();
        }

        static int GetDigitPart1(string input)
        {
            int counter = 1;
            int output = 0;

            for (int i = input.Length - 1; i > 0; i--)
            {
                if (char.IsDigit(input[i]))
                {
                    output += (input[i] - '0') * counter;
                    counter *= 10;
                }
            }

            return output;
        }

        static int GetDigitPart2(string input)
        {
            return int.Parse(new string(input.Where(char.IsDigit).ToArray()));
        }

        static int GetDigitPart3(string input)
        {
            return int.Parse(Regex.Replace(input, "[^0-9]+", string.Empty));
        }

        static int GetDigitPart4(string input)
        {
            return Convert.ToInt32(string.Join(null, System.Text.RegularExpressions.Regex.Split(input, "[^\\d]")));
        }

        static int GetDigitPart5(string input)
        {
            int output = 0;

            foreach (char c in input)
            {
                if (char.IsDigit(c))
                {
                    output = (c - '0') + output * 10;
                }
            }

            return output;
        }

        static int GetDigitPart6(string input)
        {
            int output = 0;

            for (int i = 0; i < input.Length; i++)
            {
                if (char.IsDigit(input[i]))
                {
                    output = (input[i] - '0') + output * 10;
                }
            }

            return output;
        }

        static string GetRandomString()
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var stringChars = new char[8];
            var random = new Random();

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            var finalString = new String(stringChars);

            return finalString;
        }
    }
}
