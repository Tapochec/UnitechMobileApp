using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Text;
using UnitechMobileApp.mvvm.General;
using UnitechMobileApp.ScheduleHelper;

namespace UnitechMobileApp.mvvm.Schedule.WeekPicker
{
    class WeekPickerPageViewModel : ViewModelBase
    {
        private int curMonth;
        private int curYear;

        private string monthWithYear;
        public string MonthWithYear
        {
            get { return monthWithYear; }
            set { SetProperty(ref monthWithYear, value, "MonthWithYear", OnMonthChanged); }
        }

        private List<Week> weeks;
        public List<Week> Weeks
        {
            get { return weeks; }
            set { SetProperty(ref weeks, value); }
        }

        //public Week SelectedWeek = Week.Empty;

        private CultureInfo ruCulture = CultureInfo.CreateSpecificCulture("ru");

        public WeekPickerPageViewModel()
        {
            Weeks = new List<Week>();
            curMonth = DateTime.Now.Month;
            curYear = DateTime.Now.Year;
            MonthWithYear = GetHeaderString(curMonth, curYear);
        }

        // Пример: "Март 2020"
        private string GetHeaderString(int monthNumber, int year)
        {
            DateTime date = new DateTime(year, monthNumber, 1);
            string header = date.ToString("MMMM", ruCulture);
            header += " " + date.Year.ToString();
            // О_О
            string firstLetter = header[0].ToString().ToUpper(ruCulture);
            header = header.Remove(0, 1);
            header = firstLetter + header;

            return header;
        }

        public void OnLeftArrowTapped()
        {
            curMonth--;
            if (curMonth == 0)
            {
                curMonth = 12;
                curYear--;
            }

            MonthWithYear = GetHeaderString(curMonth, curYear);
        }

        public void OnRightArrowTapped()
        {
            curMonth++;
            if (curMonth == 13)
            {
                curMonth = 1;
                curYear++;
            }

            MonthWithYear = GetHeaderString(curMonth, curYear);
        }

        private void OnMonthChanged()
        {
            List<Week> newWeeks = new List<Week>();
            DateTime start = new DateTime(curYear, curMonth, 1);
            Week currentWeek = Week.GetWeekByDateTime(start);

            do
            {
                newWeeks.Add(currentWeek);
                currentWeek = new Week(currentWeek.Sunday.AddDays(1));
            } while (currentWeek.Monday.Month == curMonth);

            Weeks = newWeeks;
        }
    }
}
