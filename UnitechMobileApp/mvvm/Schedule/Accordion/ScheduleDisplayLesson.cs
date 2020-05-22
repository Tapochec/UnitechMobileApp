using System;
using System.Collections.Generic;
using System.Text;
using UnitechMobileApp.ScheduleHelper;
using Xamarin.Forms;

namespace UnitechMobileApp.mvvm.Schedule.Accordion
{
    public class ScheduleDisplayLesson
    {
        public string Number { get; private set; }

        public HtmlWebViewSource Description { get; private set; }


        public ScheduleDisplayLesson(ScheduleLesson lesson)
        {
            string html = "";
            Number = lesson.Number.ToString();

            html = Correct(lesson.Description);
            if (lesson.Note != "")
                html += "<br/><br/>" + SetWarningColor(Correct(lesson.Note));

            Description = new HtmlWebViewSource();
            Description.Html = html;
        }

        private string Correct(string str)
        {
            return str.Replace("&lt;", "<").Replace("&gt;", ">");
        }
        
        private string SetWarningColor(string note)
        {
            //int index = note.IndexOf('>');
            //note = note.Insert(index, " style=\"color: red;\"");
            note = note.Insert(0, "<div style=\"color: red;\">");
            note = note.Insert(note.Length, "</div>");

            return note;
        }
    }
}
