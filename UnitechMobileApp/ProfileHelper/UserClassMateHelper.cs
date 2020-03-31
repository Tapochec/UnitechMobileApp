using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using UnitechMobileApp.Model;

namespace UnitechMobileApp.ProfileHelper
{
    public class UserClassMateHelper
    {
        private class RawCassMateInfo
        {
            public string fio;
            public string userid;
            public string avatar;
            public string online;
            public string activity_date;
        }

        /// <summary>
        /// Возвращает список одногруппников пользователя
        /// </summary>
        /// <param name="id">Id пользователя, для которого надо получить список одногруппников</param>
        /// <returns>Лист UserData</returns>
        public static List<ClassMateInfo> JsonToUserClassMate(string json)
        {
            var rawList = JsonConvert.DeserializeObject<List<RawCassMateInfo>>(json);
            var result = new List<ClassMateInfo>();
            foreach(var item in rawList)
            {
                var fio = item.fio.Split(' ');
                result.Add(new ClassMateInfo()
                {
                    SecondName = fio[0],
                    FirstName = fio[1],
                    ThirdName = fio.Length == 3 ? fio[2] : string.Empty,
                    Id = item.userid,
                    AvatarPath = item.avatar,
                    Avatar = Workspace.ActiveUser.GetUserAvatar(item.userid, item.avatar),
                    Online = item.online == "1",
                    ActivityDate = item.activity_date
                });
            }
            return result;
        }
    }
}
