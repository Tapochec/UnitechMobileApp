using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using UnitechMobileApp.Model;

namespace UnitechMobileApp.ProfileHelper
{

    static class UserDataConverter
    {
        private class RawUserData
        {
            public string email;
            public string phone;
            public string sbs;
            public string fio;
            public string bd;
            public string prevedu;
            public string tprevedu;
            public string avatar;
            public string departament;
            public string position;
            public string type;
            public string FacultText;
            public string SpecText;
            public string eway;
            public string GroupText;
            public string yi;
            public string eduPeriod;
            public string zt;
            public string dt;
            public string allowed;
            public string rating;
            public string online;
            public string activity_date;
            public string a_a_works;
            public string a_s_interest;
            public string count_sbs;
            public string tutor_rating;
            public string student_hash;
        }

        /// <summary>
        /// Конвертирует Json строку, полученную через api портала, в информаию о пользователе
        /// </summary>
        /// <param name="json">Json строка c информацией о пользователе</param>
        /// <returns>Объект UserData с информацией о пользователе</returns>
        public static UserData JsonToUserData(string json)
        {
            var raw = JsonConvert.DeserializeObject<RawUserData>(json);
            var result = new UserData();

            var fio = raw.fio.Split(' ');
            result.FirstName = fio[0];
            result.SecondName = fio[1];
            //the user may haven't got third name
            result.ThirdName = fio.Length == 3? fio[2]: string.Empty;

            result.UserAvatar = Workspace.ActiveUser.GetUserAvatar();
            result.Rating = double.Parse(raw.rating, CultureInfo.InvariantCulture);
            result.BirthDay = raw.bd;

            result.FacultText = raw.FacultText;
            result.SpecText = raw.SpecText;
            result.Specialization = raw.eway;
            result.GroupText = raw.GroupText;
            result.StudyStartYear = raw.yi;
            result.EducationPeriod = raw.eduPeriod;

            result.EMail = raw.email;
            result.Online = raw.online == "1";
            result.StudentHash = raw.student_hash;

            return result;
        }
    }
}
