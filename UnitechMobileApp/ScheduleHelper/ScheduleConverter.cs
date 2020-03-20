using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace UnitechMobileApp.ScheduleHelper
{
#pragma warning disable CS0649
    public static class ScheduleConverter
    {
        private class ScheduleLessonTmp
        {
            public int daynum;
            public int timenum;
            public int weeknum;
            public string lparam;
            public string note;
        }

        private class ScheduleDataTmp
        {
            // Здесь ТОЛЬКО учебные дни
            public List<ScheduleLessonTmp> data;
            // Здесь ТОЛЬКО выходные дни, могут содержать будни
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

            // Добавление учебных занятий
            for (int i = 1; i < 7; i++)
            {
                List<ScheduleLessonTmp> tmpList = loadedJson.data.FindAll(d => d.daynum == i);
                if (tmpList.Count == 0)
                    continue;

                List<ScheduleLesson> resList = tmpList.ConvertAll(
                    new Converter<ScheduleLessonTmp, ScheduleLesson>(TmpLessonToScheduleLesson));

                dayLessonsPairs.Add(i, resList);
            }

            // Добавление выходных записей (занятиями это сложно назвать)
            for (int i = 1; i < 7; i++)
            {
                List<ScheduleLessonTmp> tmpList = loadedJson.holydays.FindAll(d => d.daynum == i);
                if (tmpList.Count == 0)
                    continue;

                List<ScheduleLesson> resList = tmpList.ConvertAll(
                    new Converter<ScheduleLessonTmp, ScheduleLesson>(TmpLessonToScheduleLesson));

                resList.ForEach(l => l.IsHoliday = true);

                dayLessonsPairs.Add(i, resList);
            }

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
