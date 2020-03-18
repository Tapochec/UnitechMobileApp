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
            var dayLessonPairs = Workspace.ActiveUser.GetSchedule();

            foreach (KeyValuePair<int, List<ScheduleLesson>> pair in dayLessonPairs)
            {
                accordionVms[pair.Key - 1].Items = pair.Value;
            }
        }
    }
}
