using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ideal.Pools
{
    public static class MonthDifferencePool
    {
        private static ConcurrentDictionary<string, int> _monthDifferenceDictionary = new ConcurrentDictionary<string, int>();

        public static int GetMonthDifference(string symbol1, string symbol2)
        {
            string symbols = string.Concat(symbol1, symbol2);

            if (!_monthDifferenceDictionary.TryGetValue(symbols, out _))
            {
                _monthDifferenceDictionary[symbols] = GetDifference(symbol1, symbol2);
            }

            return _monthDifferenceDictionary[symbols];
        }

        private static int GetDifference(string symbol1, string symbol2)
        {
            DateTime symbol1Date = DatePool.GetSymbolDate(symbol1);
            DateTime symbol2Date = DatePool.GetSymbolDate(symbol2);

            return DateUtil.GetMonthDifference(symbol1Date, symbol2Date);
        }
    }
}
