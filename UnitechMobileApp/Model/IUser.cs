using System;
using System.Collections.Generic;
using System.Text;
using UnitechMobileApp.ScheduleHelper;

namespace UnitechMobileApp.Model
{
    /// <summary>
    /// Используется для реализации поведения пользователей разлиного типа
    /// </summary>
    public interface IUser
    {
        Dictionary<int, List<ScheduleLesson>> GetSchedule();
    }
}
