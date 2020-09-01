static class ParsingExtensions
    {
        private static CultureInfo _commaCultureInfo = new CultureInfo("tr-TR");

        public static decimal ToDecimal(this string value)
        {
            if (value.Contains(','))
                return decimal.Parse(value, _commaCultureInfo);

            return decimal.Parse(value, CultureInfo.InvariantCulture);
        }
    }
