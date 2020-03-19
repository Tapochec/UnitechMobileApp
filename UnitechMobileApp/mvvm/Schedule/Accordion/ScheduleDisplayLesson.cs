using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace UnitechMobileApp.mvvm.Schedule.Accordion
{
    public class ScheduleDisplayLesson
    {
        public string Number { get; private set; }

        public HtmlWebViewSource Description { get; private set; }


        public ScheduleDisplayLesson(int lessonNumber, string lessonDescription)
        {
            Number = lessonNumber.ToString();

            Description = new HtmlWebViewSource();
            Description.Html = lessonDescription.Replace("&lt;", "<").Replace("&gt;", ">");
        }
    }
}
