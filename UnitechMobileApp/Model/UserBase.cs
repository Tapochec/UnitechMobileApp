using System;
using System.Collections.Generic;
using System.Text;
using UnitechMobileApp.ScheduleHelper;
using UnitechMobileApp.Models;
using UnitechMobileApp.ProfileHelper;

namespace UnitechMobileApp.Model
{
    /// <summary>
    /// Базовый класс для всех пользователей
    /// </summary>
    public abstract class UserBase
    {
        public string Login;
        public string Password;
        public int id;

        public virtual Dictionary<int, List<ScheduleLesson>> GetSchedule()
        {
            return ScheduleConverter.JsonToShedule(Client.Schedule());
        }

        public virtual UserData GetUserData()
        {
            return UserDataConverter.JsonToUserData(Client.UserData());
        }

        abstract public List<IAcademic> JsonToListAcademics(string json);
    }
}
