using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ideal
{
    public static class FileUtil
    {
        const string FilePath = "Arbitrage.txt";
        const string JsonPath = "Teminatlar.json";
        const string TxtPath = "Teminatlar.txt";

        private static volatile object _locker = new object();

        public static void AppendText(string text)
        {
            lock (_locker)
            {
                File.AppendAllText(FilePath, string.Concat(text, "\n"));
            }
        }

        public static Dictionary<string, double> LoadTeminatDictionaryJson(string path = JsonPath)
        {
            string jsonText = File.ReadAllText(path);

            return JsonConvert.DeserializeObject<Dictionary<string, double>>(jsonText);
        }

        // This can be optimized
        // Currently, there are a lot of unnecessary heap-allocations here
        public static Dictionary<string, double> LoadTeminatDictionary(string path = TxtPath)
        {
            return File.ReadAllLines(path)
                       .Select(l => l.Split(','))
                       .ToDictionary(x => x[0].Trim(), x => Convert.ToDouble(x[1].Trim()));
        }
        
        public static Dictionary<string, double> LoadDictionaryOptimized(string path)
        {
            var lines = File.ReadAllLines(path);
            var dict = new Dictionary<string, double>();
            foreach (var line in lines)
            {
                int idx = line.IndexOf(',');
                var first = line.AsSpan(0, idx);
                var second = line.AsSpan(idx + 1, line.Length - idx - 1);
                double.TryParse(second, out var secondDbl);
                dict[first.ToString()] = secondDbl;
            }
        
            return dict;
        }

    }
}
