using System;
using System.Collections.Generic;
using System.Text;

namespace UnitechMobileApp.ScheduleHelper
{
    /// <summary>
    /// Представляет класс одного учебного занятия
    /// </summary>
    public class ScheduleLesson
    {
        /// <summary>
        /// Номер пары, начиная с 1
        /// </summary>
        public int Number;

        /// <summary>
        /// Чётность недели
        /// </summary>
        public WeekParity Week;

        /// <summary>
        /// Информация о паре (Преподователь, аудитория и т.п.). Может содержать теги <strong>, <hr>
        /// </summary>
        public string Description;

        /// <summary>
        /// Заметка. Обычно содержит информацию о празднике или переносе пары
        /// </summary>
        public string Note;

        /// <summary>
        /// Указывает, является ли день, к которому привязана запись, выходным
        /// </summary>
        public bool IsHoliday = false;
    }

    /// <summary>
    /// Чётность недели
    /// </summary>
    public enum WeekParity
    {
        Odd = 1,
        Even = 2,
        Both = 3
    }
}
