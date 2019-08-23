using System;
using System.Collections;
using System.Collections.Generic;
using ideal.Extensions;
using ideal.Pools;
using Xunit;

namespace ideal.Tests
{
    public class DateUtilTests
    {
        [Theory]
        [InlineData("F_ARCLK0719", "F_AKBNK1019", 3)]
        [InlineData("F_HALKB0919", "F_AKBNK0719", 2)]
        [InlineData("F_KCHOL1019", "F_GARAN0220", 4)]
        public void ShouldGetMonthDifference(string symbol1, string symbol2, int expected)
        {
            int actual = 0;

            if (symbol1.IsSpot() || symbol2.IsSpot())
            {
                int monthDeviation = DateUtil.GetMonthDifference(DateTime.Now, new DateTime(2019, 7, 15));

                actual += monthDeviation;
            }

            actual = DateUtil.GetMonthDifference(symbol1, symbol2);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [ClassData(typeof(GetSymbolDateClass))]
        public void ShouldGetSymbolDate(string symbol, DateTime expected)
        {
            DateTime actual = DateTime.MinValue;

            actual = DatePool.GetSymbolDate(symbol);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [ClassData(typeof(GetMonthDifferenceClass))]
        public static void ShouldGetMonthDifferenceWithDateTimes(DateTime firstDate, DateTime secondDate, int expected)
        {
            int actual = DateUtil.GetMonthDifference(firstDate, secondDate);

            Assert.Equal(expected, actual);
        }


        [Theory]
        [ClassData(typeof(GetContractMonthPoolClass))]
        public void ShouldGetContractMonth(string symbol, int expected)
        {
            int actual = DatePool.GetSymbolMonth(symbol);

            if (SymbolUtil.GetSymbolType(symbol) == SymbolType.Spot)
            {
                int monthDifference = DateTime.Now.Month - 7;

                actual -= monthDifference;
            }

            Assert.Equal(expected, actual);
        }

        [Theory]
        [ClassData(typeof(GetContractYearPoolClass))]
        public void ShouldGetContractYear(string symbol, int expected)
        {
            int actual = DatePool.GetSymbolYear(symbol);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [ClassData(typeof(GetVadeYakinPoolClass))]
        public void ShouldGetVadeYakin(string symbol1, string symbol2, int expected)
        {
            int actual = VadePool.GetVadeYakin(symbol1, symbol2);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [ClassData(typeof(GetVadeUzakPoolClass))]
        public void ShouldGetVadeUzak(string symbol1, string symbol2, int expected)
        {
            int actual = VadePool.GetVadeUzak(symbol1, symbol2);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [ClassData(typeof(GetVadeYakinUzakPoolClass))]
        public void ShouldGetVadeYakinUzak(string symbol1, string symbol2, int expected)
        {
            int actual = VadePool.GetVadeYakinUzak(symbol1, symbol2);

            Assert.Equal(expected, actual);
        }
    }

    class GetContractMonthPoolClass : IEnumerable<object[]>
    {
        private readonly List<object[]> _data = new List<object[]>
        {
            new object[] { new Symbol { Name = "AKBNK" }, 7 },
            new object[] { new Symbol { Name = "SISE" }, 7 },
            new object[] { "F_AKBNK0819", 8 },
            new object[] { "F_GARAN1220", 12 },
            new object[] { "F_SISE0620", 6 }
        };

        public IEnumerator<object[]> GetEnumerator()
        { return _data.GetEnumerator(); }

        IEnumerator IEnumerable.GetEnumerator()
        { return GetEnumerator(); }
    }

    class GetContractYearPoolClass : IEnumerable<object[]>
    {
        private readonly List<object[]> _data = new List<object[]>
        {
            new object[] { "AKBNK", DateTime.Now.Year },
            new object[] { "SISE", DateTime.Now.Year },
            new object[] { "F_AKBNK0819", 2019 },
            new object[] { "F_GARAN1220", 2020 },
            new object[] { "F_SISE1019", 2019 }
        };

        public IEnumerator<object[]> GetEnumerator()
        { return _data.GetEnumerator(); }

        IEnumerator IEnumerable.GetEnumerator()
        { return GetEnumerator(); }
    }

    class GetSymbolDateClass : IEnumerable<object[]>
    {
        private readonly List<object[]> _data = new List<object[]>
        {
            new object[] { "F_PETKM0919", new DateTime(2019, 9, 30) },
            new object[] { "F_KOZAA1019", new DateTime(2019, 10, 31) },
            new object[] { "ENJSA", new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month)) },
            new object[] { "F_VAKBN1219", new DateTime(2019, 12, 31) },
            new object[] { "F_YKBNK0220", new DateTime(2020, 2, 29) }
        };

        public IEnumerator<object[]> GetEnumerator()
        { return _data.GetEnumerator(); }

        IEnumerator IEnumerable.GetEnumerator()
        { return GetEnumerator(); }
    }

    class GetMonthDifferenceClass : IEnumerable<object[]>
    {
        private readonly List<object[]> _data = new List<object[]>
        {
            new object[] { new DateTime(2019, 5, 25), new DateTime(2019, 9, 30), 4 },
            new object[] { new DateTime(2019, 10, 31), new DateTime(2019, 12, 18), 2 },
            new object[] { new DateTime(2020, 2, 02), new DateTime(2019, 11, 16), 3 },
            new object[] { new DateTime(2019, 12, 15), new DateTime(2020, 4, 25), 4 },
            new object[] { new DateTime(2020, 2, 28), new DateTime(2018, 6, 24), 20 }
        };

        public IEnumerator<object[]> GetEnumerator()
        { return _data.GetEnumerator(); }

        IEnumerator IEnumerable.GetEnumerator()
        { return GetEnumerator(); }
    }

    class GetVadeYakinPoolClass : IEnumerable<object[]>
    {
        private readonly List<object[]> _data = new List<object[]>
        {
            new object[] { "AKBNK", "F_AKBNK0719", 0 },
            new object[] { "F_AKBNK1019", "F_AKBNK1119", (new DateTime(2019, 10, 31) - DateTime.Now).Days },
            new object[] { "F_GARAN0819", "F_GARAN0919", (new DateTime(2019, 8, 31) - DateTime.Now).Days },
            new object[] { "F_SISE0919", "F_SISE0120", (new DateTime(2019, 9, 30) - DateTime.Now).Days },
            new object[] { "F_SISE1119", "F_SISE1219", (new DateTime(2019, 11, 30) - DateTime.Now).Days }
        };

        public IEnumerator<object[]> GetEnumerator()
        { return _data.GetEnumerator(); }

        IEnumerator IEnumerable.GetEnumerator()
        { return GetEnumerator(); }
    }

    class GetVadeUzakPoolClass : IEnumerable<object[]>
    {
        private readonly List<object[]> _data = new List<object[]>
        {
            new object[] { "AKBNK", "F_AKBNK0719", (new DateTime(2019, 7, 31) - DateTime.Now).Days },
            new object[] { "F_AKBNK1019", "F_AKBNK1119", (new DateTime(2019, 11, 30) - DateTime.Now).Days },
            new object[] { "F_GARAN0819", "F_GARAN0919", (new DateTime(2019, 9, 30) - DateTime.Now).Days },
            new object[] { "F_SISE0919", "F_SISE0120", (new DateTime(2020, 1, 31) - DateTime.Now).Days },
            new object[] { "F_SISE1119", "F_SISE1219", (new DateTime(2019, 12, 31) - DateTime.Now).Days }
        };

        public IEnumerator<object[]> GetEnumerator()
        { return _data.GetEnumerator(); }

        IEnumerator IEnumerable.GetEnumerator()
        { return GetEnumerator(); }
    }

    class GetVadeYakinUzakPoolClass : IEnumerable<object[]>
    {
        private readonly List<object[]> _data = new List<object[]>
        {
            new object[] { "AKBNK", "F_SAHOL0819", VadePool.GetVadeUzak("AKBNK", "F_SAHOL0819") - VadePool.GetVadeYakin("AKBNK", "F_SAHOL0819") },
            new object[] { "SISE", "F_SISE1019", VadePool.GetVadeUzak("SISE", "F_SISE1019") - VadePool.GetVadeYakin("SISE", "F_SISE1019") },
            new object[] { "F_AKBNK0719", "F_SAHOL0819", VadePool.GetVadeUzak("F_AKBNK0719", "F_SAHOL0819") - VadePool.GetVadeYakin("F_AKBNK0719", "F_SAHOL0819") },
            new object[] { "F_GARAN0719", "F_HALKB0919", VadePool.GetVadeUzak("F_GARAN0719", "F_HALKB0919") - VadePool.GetVadeYakin("F_GARAN0719", "F_HALKB0919") },
            new object[] { "F_SISE0719", "F_ENJSA1219", VadePool.GetVadeUzak("F_SISE0719", "F_ENJSA1219") - VadePool.GetVadeYakin("F_SISE0719", "F_ENJSA1219") },
            new object[] { "F_SISE0819", "F_TTKOM0919", VadePool.GetVadeUzak("F_SISE0819", "F_TTKOM0919") - VadePool.GetVadeYakin("F_SISE0819", "F_TTKOM0919") }
        };

        public IEnumerator<object[]> GetEnumerator()
        { return _data.GetEnumerator(); }

        IEnumerator IEnumerable.GetEnumerator()
        { return GetEnumerator(); }
    }
}
