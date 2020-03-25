using System;
using System.Collections.Generic;
using System.Text;

namespace UnitechMobileApp.ScheduleHelper
{
    public struct Week
    {
        public readonly DateTime Monday;
        public readonly DateTime Sunday;

        public static Week Empty => new Week();

        public Week(DateTime monday, DateTime sunday)
        {
            if (!IsValid(monday, sunday))
            {
                Monday = DateTime.MinValue;
                Sunday = DateTime.MinValue;
            }
            else
            {
                Monday = monday;
                Sunday = sunday;
            }
        }

        public string GetDisplayString(string format = "dd.MM.yyyy", string separator = " - ")
        {
            return Monday.ToString(format) + separator + Sunday.ToString(format);
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
