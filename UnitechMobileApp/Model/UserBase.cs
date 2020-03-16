using System;
using System.Collections.Generic;
using System.Text;
using UnitechMobileApp.ScheduleHelper;

namespace UnitechMobileApp.Model
{
    /// <summary>
    /// Базовый класс для всех пользователей
    /// </summary>
    public abstract class UserBase
    {
        public string Login;
        public string Password;

        public virtual Dictionary<int, List<ScheduleLesson>> GetSchedule()
        {
            return null;
        }
    }

    public enum UserType
    {
        Student,
        Teacher
    }
}
