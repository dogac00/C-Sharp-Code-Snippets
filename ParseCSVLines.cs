using System;
using System.IO;
using System.Linq;

namespace ModelParser
{
    class Program
    {
        public static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines(@"MyFolder.csv");

            string text1 = lines.Where(line => line.Contains("MY_KEY_WORD"))
                .Select(line => line.Split(',')[1])
                .Select(line => line.Replace("\"", ""))
                .Aggregate((line1, line2) => string.Concat(line1, ",", line2));

            string text2 = lines.Where(line => line.Contains("MY_KEY_WORD"))
                .Select(line => line.Split(',')[1])
                .Select(line => line.Replace("\"", ""))
                .Aggregate((line1, line2) => string.Join(",", line1, line2));

            string text3 = string.Join(",", lines.Where(line => line.Contains("MY_KEY_WORD"))
                .Select(line => line.Split(',')[1])
                .Select(line => line.Replace("\"", "")));

            Console.WriteLine(text1 == text2);
            Console.WriteLine(text1 == text3);
            Console.WriteLine(text2 == text3);
        }
    }
}
