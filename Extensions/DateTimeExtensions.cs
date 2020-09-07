using System;

namespace Extensions
{
    public static class DateTimeExtensions
    {
        public static long ToUnixTimeMilliseconds(this DateTime date)
        {
            var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            
			return Convert.ToInt64((date - epoch).TotalMilliseconds);
        }

        public static long ToUnixTimeSeconds(this DateTime date)
        {
            var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            
			return Convert.ToInt64((date - epoch).TotalSeconds);
        }
    }
}
