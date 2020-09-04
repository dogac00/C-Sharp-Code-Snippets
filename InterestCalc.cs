private static double CalculateDailyInterest(double interestRate)
        {
            int today = DateTime.Now.Day;
            int daysOfMonth = DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month);

            int dayDifference = daysOfMonth - today;

            return (double) dayDifference / daysOfMonth * interestRate;
        }

        private static double CalculateMonthlyInterest(string symbol1, string symbol2, double interestRate)
        {
            return DateUtil.GetMonthDifference(symbol1, symbol2) * interestRate;
        }

        private static double CalculateMonthlyInterest(string symbol, double interestRate)
        {
            DateTime symbolDate = DatePool.GetSymbolDate(symbol);

            int monthDifference = DateUtil.GetMonthDifference(symbolDate, DateTime.Now);

            return monthDifference * interestRate;
        }

        private static double CalculateArbitrageThreshold(string symbol1, string symbol2, double interestRate, double profitRate)
        {
            interestRate += profitRate;

            double dailyInterest, monthlyInterest;

            if (symbol1.IsSpot())
            {
                dailyInterest = CalculateDailyInterest(interestRate);
                monthlyInterest = CalculateMonthlyInterest(symbol2, interestRate);
            }
            else
            {
                dailyInterest = 0;
                monthlyInterest = DateUtil.GetMonthDifference(symbol1, symbol2) * interestRate;
            }

            return dailyInterest + monthlyInterest;
        }
