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

        public Dictionary<int, List<ScheduleLesson>> DayLessonsPairs;
    }
}
