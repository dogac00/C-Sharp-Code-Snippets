using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ReadOhlc
{
    internal class Program
    {
        private const string path = "USD_TRY Historical Data.csv";

        static void Main(string[] args)
        {
            var lines = File.ReadAllLines(path).Reverse();
            StringBuilder sb = new StringBuilder();

            foreach (string line in lines)
            {
                var data = line.Split(',');
                int mon = GetMonthValue(ReplaceQuotes(data[0]).Split(" ")[0]);
                string day = ReplaceQuotes(data[0]).Split(" ")[1];
                string year = ReplaceSpace(ReplaceQuotes(data[1]));
                var date = $"new Date({year},{mon},{day})";
                var open = double.Parse(ReplaceQuotes(data[2]), CultureInfo.InvariantCulture);
                var high = double.Parse(ReplaceQuotes(data[3]), CultureInfo.InvariantCulture);
                var low = double.Parse(ReplaceQuotes(data[4]), CultureInfo.InvariantCulture);
                var closed = double.Parse(ReplaceQuotes(data[5]), CultureInfo.InvariantCulture);

                string concatted = string.Concat("[", date.ToString(CultureInfo.InvariantCulture), 
                    ",", closed.ToString(CultureInfo.InvariantCulture), "],\r\n");

                sb.Append(concatted);
            }

            File.WriteAllText("NewData.csv", sb.ToString());
        }

        static string ReplaceQuotes(string input)
        {
            return input.Replace("\"", "");
        }

        static string ReplaceSpace(string input)
        {
            return input.Replace(" ", "");
        }

        static int GetMonthValue(string month)
        {
            switch (month)
            {
                case "Jan":
                    return 1;
                case "Feb":
                    return 2;
                case "Mar":
                    return 3;
                case "Apr":
                    return 4;
                case "May":
                    return 5;
                case "Jun":
                    return 6;
                case "Jul":
                    return 7;
                case "Aug":
                    return 8;
                case "Sep":
                    return 9;
                case "Oct":
                    return 10;
                case "Nov":
                    return 11;
                case "Dec":
                    return 12;
                default:
                    throw new InvalidEnumArgumentException("Invalid value");
            }
        }
    }
}
