using System;

namespace YearPlanner.Common.Extensions
{
    public static class DateTimeExtensions
    {
        public static int DaysInMonth(this DateTime dt)
        {
            if (dt.Year == DateTime.MaxValue.Year && dt.Month == 12)
            {
                return 31;
            }
            return dt.AddMonths(1).AddDays(-1).Day;
        }
    }
}