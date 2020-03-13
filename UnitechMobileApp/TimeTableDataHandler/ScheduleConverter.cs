using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace TimeTable
{
    public class ScheduleDay
    {
        /// <summary>
        /// Номер дня, начиная с 1
        /// </summary>
        public int daynum;

        /// <summary>
        /// Номер пары, начиная с 1
        /// </summary>
        public int timenum;

        /// <summary>
        /// Чётность недели. 1 - чётная, 2 - не чётная 3 - по обеим
        /// </summary>
        public int weeknum;

        /// <summary>
        /// Информация о паре (Преподователь, аудитория и т.п.). Может содержать теги <strong>, <hr>
        /// </summary>
        public string lparam;

        /// <summary>
        /// Заметка. Обычно содержит информацию о празднике
        /// </summary>
        public string note;
    }

    public static class ScheduleConverter
    {
        private class ScheduleData
        {
            internal List<ScheduleDay> data;
            internal List<ScheduleDay> holydays;
        }

        //public static ScheduleData JsonToScheduleData(string rawData)
        //{
        //    ScheduleData loadedJson = JsonConvert.DeserializeObject<ScheduleData>(rawData);

        //    filtering data from holidays
        //    foreach (ScheduleDay holyday in loadedJson.holydays)
        //    {
        //        for (int i = 0; i < loadedJson.data.Count; ++i)
        //        {
        //            if (loadedJson.data[i].daynum == holyday.daynum)
        //            {
        //                loadedJson.data[i] = holyday;
        //            }
        //        }
        //    }
        //    return loadedJson;
        //}

        /// <summary>
        /// Принимает на вход json и парсит его в объект. Пары, которые выпали на праздничный день, заменяются на праздник
        /// </summary>
        public static Dictionary<int, List<ScheduleDay>> JsonToLessons(string rawData)
        {
            ScheduleData loadedJson = JsonConvert.DeserializeObject<ScheduleData>(rawData);

            Dictionary<int, List<ScheduleDay>> dayLessonsPairs = new Dictionary<int, List<ScheduleDay>>();
            for (int i = 1; i < 6; i++)
            {
                dayLessonsPairs.Add(i, loadedJson.data.FindAll(d => d.daynum == i));
            }
            dayLessonsPairs.Add(6, loadedJson.holydays.FindAll(d => d.daynum == 1));

            return dayLessonsPairs;
        }
    }
}
