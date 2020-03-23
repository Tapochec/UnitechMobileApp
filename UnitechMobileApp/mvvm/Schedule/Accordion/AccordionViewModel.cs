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
        private bool enabled;
        public bool Enabled
        {
            get { return enabled; }
            set { SetProperty(ref enabled, value); }
        }


        public List<ScheduleDisplayLesson> lessons;
        public List<ScheduleDisplayLesson> Lessons
        {
            get { return lessons; }
            set
            {
                SetProperty(ref lessons, value);

                if (lessons?.Count == 0)
                    Enabled = false;
                else
                    Enabled = true;
            }
        }

        public AccordionViewModel()
        {
            Lessons = new List<ScheduleDisplayLesson>();
        }
    }
}
