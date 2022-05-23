namespace Housing.Data.Helpers
{
    public static class DateHelper
    {
        public static DateTime Now => DateTime.Now;
        public static DateTime CurrentMonth => new(Now.Year, Now.Month, 1);
        public static DateTime CurrentYear => new(Now.Year, 1, 1);
        public static DateTime GetMonth(DateTime date) => new(date.Year, date.Month, 1);
        public static DateTime GetMonth(int year, int month) => new(year, month, 1);
        public static DateTime GetYear(DateTime date) => new(date.Year, 1, 1);
        public static DateTime GetYear(int year) => new(year, 1, 1);
        public static DateTime GetQuarter(int year, int month) => month % 3 == 0 ? new(year, month - 2, 1) : new(year, Convert.ToInt16(Math.Floor((double)month / 3)) * 3 + 1, 1);
    }
}
