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

        public virtual Dictionary<int, List<ScheduleLesson>> GetSchedule()
        {
            return null;
        }

        abstract public List<IAcademic> JsonToListAcademics(string json);
    }

    public enum UserType
    {
        Student,
        Teacher
    }
}
