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
        public string avatarPath;

        public virtual ScheduleData GetSchedule()
        {
            return ScheduleConverter.JsonToShedule(Client.Schedule());
        }

        public virtual UserData GetUserData()
        {
            return UserDataConverter.JsonToUserData(Client.UserData());
        }

        public virtual UserData GetUserData(string userID)
        {
            return UserDataConverter.JsonToUserData(Client.UserData(userID));
        }

        public virtual List<ClassMateInfo> GetUserClassMates()
        {
            return UserClassMateHelper.JsonToUserClassMate(Client.UserClassMate());
        }

        public virtual List<ClassMateInfo> GetUserClassMates(string id)
        {
            return UserClassMateHelper.JsonToUserClassMate(Client.UserClassMate(id));
        }

        public virtual Xamarin.Forms.ImageSource GetUserAvatar()
        {
            //todo: Если пользователь уже залогинен, то дёргать картинку из памяти устройства, а не из интернета
            return Client.Avatar();
        }
        public virtual Xamarin.Forms.ImageSource GetUserAvatar(string id, string avatar)
        {
            //todo: Если пользователь уже залогинен, то дёргать картинку из памяти устройства, а не из интернета
            return Client.Avatar(id, avatar);
        }

        public virtual ScheduleData GetSchedule(Week week)
        {
            return ScheduleConverter.JsonToShedule(Client.Schedule(week));
        }

        abstract public List<IAcademic> JsonToListAcademics(string json);
    }
}
