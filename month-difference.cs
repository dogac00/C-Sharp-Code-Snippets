[Theory]
[InlineData("F_ARCLK0719", "F_AKBNK1019", 3)]
[InlineData("F_HALKB0919", "F_AKBNK0719", 2)]
[InlineData("F_KCHOL1019", "F_GARAN0220N1", 4)]
[InlineData("F_KOZAA0219", "F_SODA0719", 5)]
[InlineData("F_GARAN0119", "F_SODA0119", 0)]
public void ShouldGetMonthDifference(string symbol1, string symbol2, int expected)
{
    int actual = MonthDifferencePool.GetMonthDifference(symbol1, symbol2);

    Assert.Equal(expected, actual);
}
