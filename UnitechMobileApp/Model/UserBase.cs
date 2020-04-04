using System;
using System.Collections.Generic;
using System.Text;
using UnitechMobileApp.ScheduleHelper;
using UnitechMobileApp.Models;

namespace UnitechMobileApp.Model
{
    /// <summary>
    /// Базовый класс для всех пользователей
    /// </summary>
    public abstract class UserBase
    {
        public string Login;
        public string Password;

        public virtual ScheduleData GetSchedule()
        {
            return ScheduleConverter.JsonToShedule(Client.Schedule());
        }

        public virtual ScheduleData GetSchedule(Week week)
        {
            return ScheduleConverter.JsonToShedule(Client.Schedule(week));
        }

        abstract public List<IAcademic> JsonToListAcademics(string json);
    }
}
