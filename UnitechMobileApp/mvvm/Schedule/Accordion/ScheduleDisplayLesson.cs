using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace UnitechMobileApp.mvvm.Schedule.Accordion
{
    public class ScheduleDisplayLesson
    {
        public string Number { get; private set; }

        public HtmlWebViewSource Desc { get; private set; }


        public ScheduleDisplayLesson(int lessonNumber, string lessonDescription)
        {
            Number = lessonNumber.ToString();

            Desc = new HtmlWebViewSource();
            Desc.Html = lessonDescription.Replace("&lt;", "<").Replace("&gt;", ">");
        }
    }
}
