using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace UnitechMobileApp.ScheduleHelper
{
    public static class ScheduleConverter
    {
        public class ScheduleLessonTmp
        {
            public int daynum;
            public int timenum;
            public int weeknum;
            public string lparam;
            public string note;
        }

        public class ScheduleDataTmp
        {
            public List<ScheduleLessonTmp> data;
            public List<ScheduleLessonTmp> holydays;
        }

        /// <summary>
        /// Конвертирует Json строку, полученную через api портала, в расписание в удобом формате
        /// </summary>
        /// <param name="scheduleRawData">Json строка расписания</param>
        /// <returns>Словарь, где Key - номер дня, Value - список занятий</returns>
        public static Dictionary<int, List<ScheduleLesson>> JsonToShedule(string scheduleRawData)
        {
            ScheduleDataTmp loadedJson = JsonConvert.DeserializeObject<ScheduleDataTmp>(scheduleRawData);

            Dictionary<int, List<ScheduleLesson>> dayLessonsPairs = new Dictionary<int, List<ScheduleLesson>>();
            // Добавление будней
            for (int i = 1; i < 6; i++)
            {
                dayLessonsPairs.Add(i, loadedJson.data
                    .FindAll(d => d.daynum == i)
                    .ConvertAll(new System.Converter<ScheduleLessonTmp, ScheduleLesson>(TmpLessonToScheduleLesson)));
            }

            // Добавление субботы
            dayLessonsPairs.Add(6, loadedJson.holydays
                .FindAll(d => d.daynum == 1)
                .ConvertAll(new System.Converter<ScheduleLessonTmp, ScheduleLesson>(TmpLessonToScheduleLesson)));

            return dayLessonsPairs;
        }

        private static ScheduleLesson TmpLessonToScheduleLesson(ScheduleLessonTmp tmp)
        {
            ScheduleLesson lesson = new ScheduleLesson
            {
                Number = tmp.timenum,
                Week = (WeekParity)tmp.weeknum,
                Description = tmp.lparam,
                Note = tmp.note
            };

            return lesson;
        }
    }
}
