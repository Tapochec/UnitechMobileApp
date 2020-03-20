using System;
using System.Collections.Generic;
using System.Text;
using UnitechMobileApp.Model;
using UnitechMobileApp.mvvm.General;
using UnitechMobileApp.mvvm.Schedule.Accordion;
using UnitechMobileApp.ScheduleHelper;

namespace UnitechMobileApp.mvvm.Schedule
{
    public class SchedulePageViewModel : ViewModelBase
    {
        public SchedulePageViewModel(List<AccordionViewModel> accordionVms)
        {
            Load(accordionVms);
        }

        public void Load(List<AccordionViewModel> accordionVms)
        {
            ScheduleData schedule = Workspace.ActiveUser.GetSchedule();

            // Загрузка параметров
            // . . .

            // Загрузка расписания
            var dayLessonsPairs = schedule.DayLessonsPairs;
            foreach (KeyValuePair<int, List<ScheduleLesson>> day in dayLessonsPairs)
            {
                List<ScheduleDisplayLesson> displayLessons = new List<ScheduleDisplayLesson>();
                foreach (ScheduleLesson lesson in day.Value)
                {
                    displayLessons.Add(new ScheduleDisplayLesson(lesson.Number, lesson.Description));
                }
                accordionVms[day.Key - 1].Lessons = displayLessons;
            }
        }
    }
}
