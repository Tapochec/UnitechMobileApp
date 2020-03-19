using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using UnitechMobileApp.mvvm.General;
using UnitechMobileApp.ScheduleHelper;
using Xamarin.Forms;

namespace UnitechMobileApp.mvvm.Schedule.Accordion
{
    public class AccordionViewModel : ViewModelBase
    {
        public List<ScheduleDisplayLesson> lessons;
        public List<ScheduleDisplayLesson> Lessons
        {
            get { return lessons; }
            set { SetProperty(ref lessons, value);  }
        }

        public AccordionViewModel()
        {
            Lessons = new List<ScheduleDisplayLesson>();
        }
    }
}
