namespace Housing.Data.Helpers
{
    public static class DateHelper
    {
        public static DateOnly Now => DateOnly.FromDateTime(DateTime.Now);
        public static DateOnly CurrentMonth => new(Now.Year, Now.Month, 1);
        public static DateOnly CurrentYear => new(Now.Year, 1, 1);

        public static DateOnly GetNextMonth(DateOnly date)
        {
            var nextDate = date.AddMonths(1).AddDays(-1);
            return GetMonth(nextDate);
        }
        public static DateOnly GetMonth(DateOnly date) => GetMonth(date.Year, date.Month);
        public static DateOnly GetMonth(int year, int month) => new(year, month, 1);

        public static DateOnly GetNextYear(DateOnly date)
        {
            var nextDate = date.AddYears(1).AddDays(-1);
            return GetYear(nextDate);
        }
        public static DateOnly GetYear(DateOnly date) => GetYear(date.Year);
        public static DateOnly GetYear(int year) => new(year, 1, 1);
        public static DateOnly GetYearEnd(int year) => new(year, 12, 1);

        public static DateOnly GetNextQuarter(DateOnly date)
        {
            var nextDate = date.AddMonths(3).AddDays(-1);
            return GetQuarter(nextDate);
        }
        public static DateOnly GetQuarter(DateOnly date) => GetQuarter(date.Year, date.Month);
        public static DateOnly GetQuarter(int year, int month) => month % 3 == 0
            ? new(year, month - 2, 1)
            : new(year, Convert.ToInt16(Math.Floor((double)month / 3)) * 3 + 1, 1);

        public const byte MONTH_NUMBER = 11;
        public static void ForEachMonth(this DateOnly start, Action<DateOnly, int> eachMonthFunc)
        {
            for (int i = 0; i < MONTH_NUMBER; i++)
            {
                var date = start.AddMonths(i);
                eachMonthFunc(date, i);
            }
        }
    }
}
