using System;
using System.Collections.Generic;
using System.Text;
using UnitechMobileApp.Model;

namespace UnitechMobileApp.mvvm.Schedule
{
    public class SchedulePageViewModel
    {
        public SchedulePageViewModel()
        {
            Load();
        }

        public void Load()
        {
            Workspace.ActiveUser.GetSchedule();
        }
    }
}
