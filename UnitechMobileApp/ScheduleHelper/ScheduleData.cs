using System;
using System.Collections.Generic;
using System.Text;

namespace UnitechMobileApp.ScheduleHelper
{
    /// <summary>
    /// Содержит в себе всю необходимую информацию о расписании
    /// </summary>
    public class ScheduleData
    {
        public WeekParity WeekParity;
        public int WeekNumber;
        public int Semester;
        public DateTime StartDate;
        public DateTime EndDate;

        public Dictionary<int, List<ScheduleLesson>> DayLessonsPairs;

        public string GetHeaderText()
        {
            string result = "";

            result += WeekNumber.ToString() + "-я, ";

            if (WeekParity == WeekParity.Odd)
                result += "нечётная неделя, ";
            else if (WeekParity == WeekParity.Even)
                result += "чётная неделя, ";

            if (Semester == 1)
                result += "осенний семестр";
            else
                result += "весенний семестр";

            return result;
        }
    }
}
