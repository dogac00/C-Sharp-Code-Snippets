using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ideal.Pools;

// A code snippet from our ideal integrator
namespace ideal
{
    public static class DateUtil
    {
        // Differences are cached
        // symbol1 is like F_AKBNK0820
        // symbol2 is like F_AKBNK1020
        // month difference here is 2
        public static int GetMonthDifference(string symbol1, string symbol2)
        {
            return MonthDifferencePool.GetMonthDifference(symbol1, symbol2);
        }

        public static int GetMonthDifference(DateTime firstDate, DateTime secondDate)
        {
            return Math.Abs((firstDate.Year - secondDate.Year) * 12 + firstDate.Month - secondDate.Month);
        }
    }
}
