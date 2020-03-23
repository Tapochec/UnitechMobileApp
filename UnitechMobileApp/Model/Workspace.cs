using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using UnitechMobileApp.ScheduleHelper;

namespace UnitechMobileApp.Model
{
    /// <summary>
    /// Класс содержит основные методы для работы с приложением
    /// </summary>
    public static class Workspace
    {
        public static UserBase ActiveUser { get; private set; }

        /// <summary>
        /// Определяет, какой пользователь авторизовался и делает его "активным"
        /// </summary>
        /// <param name="json">Результат выполнения AUTH</param>
        public static void SetUserActive(string json)
        {
            int userType = int.Parse(JObject.Parse(json)["user_type"].ToString());
            int userID = int.Parse(JObject.Parse(json)["id"].ToString());
            string avatar = JObject.Parse(json)["avatar"].ToString();
            if (userType == 2)
            {
                ActiveUser = new StudentBehavior();
            }
            else
            {
                ActiveUser = new TeacherBehavior();
            }
            ActiveUser.id = userID;
            ActiveUser.avatarPath = avatar;
        }
    }
}
