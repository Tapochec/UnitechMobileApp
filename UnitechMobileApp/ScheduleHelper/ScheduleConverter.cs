using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
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

        private class ScheduleParamsTmp
        {
            public string date_from;
            public string date_to;
            public int week_number;
            public int week_parity;
            public int semester;
        }

        private class ScheduleDataTmp
        {
            // Здесь ТОЛЬКО учебные дни
            public List<ScheduleLessonTmp> data;
            // Здесь ТОЛЬКО выходные дни, могут содержать будни
            public List<ScheduleLessonTmp> holydays;
            // Здесь хранятся общие данные
            public ScheduleParamsTmp @params;
        }

        /// <summary>
        /// Конвертирует Json строку, полученную через api портала, в расписание в удобом формате
        /// </summary>
        /// <param name="scheduleRawData">Json строка расписания</param>
        /// <returns>Словарь, где Key - номер дня, Value - список занятий</returns>
        public static ScheduleData JsonToShedule(string scheduleRawData)
        {
            ScheduleDataTmp loadedJson = JsonConvert.DeserializeObject<ScheduleDataTmp>(scheduleRawData);

            // Добавление параметров
            ScheduleData schedule = new ScheduleData
            {
                WeekNumber = loadedJson.@params.week_number,
                WeekParity = (WeekParity)loadedJson.@params.week_parity,
                Semester = loadedJson.@params.semester,
                DayLessonsPairs = new Dictionary<int, List<ScheduleLesson>>()
            };
            DateTime monday = DateTime.ParseExact(loadedJson.@params.date_from, "yyyyMMdd", CultureInfo.InvariantCulture);
            DateTime sunday = DateTime.ParseExact(loadedJson.@params.date_to, "yyyyMMdd", CultureInfo.InvariantCulture);
            schedule.Week = new Week(monday, sunday);

            // Добавление учебных занятий
            for (int i = 1; i < 7; i++)
            {
                List<ScheduleLessonTmp> tmpList = loadedJson.data.FindAll(d => d.daynum == i);
                if (tmpList.Count == 0)
                    continue;

                List<ScheduleLesson> resList = tmpList.ConvertAll(
                    new Converter<ScheduleLessonTmp, ScheduleLesson>(TmpLessonToScheduleLesson));

                schedule.DayLessonsPairs.Add(i, resList);
            }

            // Добавление выходных записей (занятиями это сложно назвать)
            for (int i = 1; i < 7; i++)
            {
                List<ScheduleLessonTmp> tmpList = loadedJson.holydays.FindAll(d => d.daynum == i);
                if (tmpList.Count == 0)
                    continue;

                List<ScheduleLesson> resList = tmpList.ConvertAll(
                    new Converter<ScheduleLessonTmp, ScheduleLesson>(TmpLessonToScheduleLesson));

                //resList.ForEach(l => l.IsHoliday = true);

                schedule.DayLessonsPairs.Add(i, resList);
            }

            return schedule;
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

        /// <summary>
        /// Определяет, является день праздничным
        /// </summary>
        /// <param name="day">Список с занятиями одного дня</param>
        /// <returns></returns>
        public static bool IsHoliday(this List<ScheduleLesson> day)
        {
            foreach (var lesson in day)
            {
                if (string.IsNullOrEmpty(lesson.Note))
                    return false;
            }

            return true;
        }
    }
}
