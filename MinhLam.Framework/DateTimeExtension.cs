using System;

namespace MinhLam.Framework
{
    public static class DateTimeExtensions
    {
        public static bool CompareOnlyDate(this DateTime date1, DateTime date2)
        {
            return date1.Day == date2.Day && date1.Month == date2.Month && date1.Year == date2.Year;
        }
    }
}
