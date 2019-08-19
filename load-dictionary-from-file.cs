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

        public static Dictionary<string, double> LoadTeminatDictionary(string path = TxtPath)
        {
            return File.ReadAllLines(path)
                       .Select(l => l.Split(','))
                       .ToDictionary(x => x[0].Trim(), x => Convert.ToDouble(x[1].Trim()));
        }
    }
}
