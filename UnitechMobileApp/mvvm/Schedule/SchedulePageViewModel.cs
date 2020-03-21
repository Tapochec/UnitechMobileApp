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
        private List<AccordionViewModel> accordionViewModels;

        public SchedulePageViewModel(List<AccordionViewModel> accordionVms)
        {
            accordionViewModels = accordionVms;
            Load();
        }

        /// <summary>
        /// Метод получает данные о текущем расписании и загружает их в интерфейс
        /// </summary>
        public void Load()
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
                accordionViewModels[day.Key - 1].Lessons = displayLessons;
            }
        }
    }
}
