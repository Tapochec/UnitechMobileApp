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

        public static void SetUserActive(UserType userType)
        {
            if (userType == UserType.Student)
            {
                ActiveUser = new StudentBehavior();
            }
            else
            {
                ActiveUser = new TeacherBehavior();
            }
        }
    }
}
