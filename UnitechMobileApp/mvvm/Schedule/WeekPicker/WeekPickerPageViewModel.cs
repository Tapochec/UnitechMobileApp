using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Text;
using UnitechMobileApp.mvvm.General;

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

        private CultureInfo ruCulture = CultureInfo.CreateSpecificCulture("ru");

        public WeekPickerPageViewModel()
        {
            curMonth = DateTime.Now.Month;
            curYear = DateTime.Now.Year;
            MonthWithYear = GetMonthString(curMonth, curYear);
        }

        private string GetMonthString(int monthNumber, int year)
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

            MonthWithYear = GetMonthString(curMonth, curYear);
        }

        public void OnRightArrowTapped()
        {
            curMonth++;
            if (curMonth == 13)
            {
                curMonth = 1;
                curYear++;
            }

            MonthWithYear = GetMonthString(curMonth, curYear);
        }

        private void OnMonthChanged()
        {
            
        }
    }
}
