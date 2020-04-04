using System;
using System.Collections.Generic;

namespace UnitechMobileApp.ScheduleHelper
{
    public struct Week
    {
        public DateTime Monday { get; private set; }

        public DateTime Tuesday => Monday.AddDays(1);
        public DateTime Wednesday => Monday.AddDays(2);
        public DateTime Thursday => Monday.AddDays(3);
        public DateTime Friday => Monday.AddDays(4);
        public DateTime Saturday => Monday.AddDays(5);
        public DateTime Sunday => Monday.AddDays(6);

        public static Week Empty => new Week();
        

        public Week(DateTime monday)
        {
            if (monday.DayOfWeek != DayOfWeek.Monday)
            {
                Monday = DateTime.MinValue;
            }
            else
            {
                Monday = monday;
            }
        }

        public string GetDisplayString(string format = "dd.MM.yyyy", string separator = " - ")
        {
            return Monday.ToString(format) + separator + Sunday.ToString(format);
        }

        public static Week GetWeekByInnerDay(DateTime day)
        {
            if (day.DayOfWeek == DayOfWeek.Sunday)
                return new Week(day.AddDays(-6));

            DateTime monday = day.AddDays(-((int)day.DayOfWeek - 1));
            return new Week(monday);
        }

        public static bool IsValid(DateTime monday, DateTime sunday)
        {
            if (monday.DayOfWeek == DayOfWeek.Monday &&
                sunday.DayOfWeek == DayOfWeek.Sunday &&
                ((sunday - monday).TotalDays == 6))
                return true;

            return false;
        }
    }
}
