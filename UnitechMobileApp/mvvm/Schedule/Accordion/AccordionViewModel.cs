using System;
using System.Collections.Generic;
using System.Text;
using UnitechMobileApp.mvvm.General;
using UnitechMobileApp.ScheduleHelper;
using Xamarin.Forms;

namespace UnitechMobileApp.mvvm.Schedule.Accordion
{
    public class AccordionViewModel : ViewModelBase
    {
        public AccordionViewModel()
        {
            
        }

        #region Lessons properties

        private HtmlWebViewSource lesson1;
        public HtmlWebViewSource Lesson1
        {
            get { return lesson1; }
            set { SetProperty(ref lesson1, value); }
        }

        private HtmlWebViewSource lesson2;
        public HtmlWebViewSource Lesson2
        {
            get { return lesson2; }
            set { SetProperty(ref lesson2, value); }
        }

        private HtmlWebViewSource lesson3;
        public HtmlWebViewSource Lesson3
        {
            get { return lesson3; }
            set { SetProperty(ref lesson3, value); }
        }

        private HtmlWebViewSource lesson4;
        public HtmlWebViewSource Lesson4
        {
            get { return lesson4; }
            set { SetProperty(ref lesson4, value); }
        }

        private HtmlWebViewSource lesson5;
        public HtmlWebViewSource Lesson5
        {
            get { return lesson5; }
            set { SetProperty(ref lesson5, value); }
        }

        private HtmlWebViewSource lesson6;
        public HtmlWebViewSource Lesson6
        {
            get { return lesson6; }
            set { SetProperty(ref lesson6, value); }
        }

        private HtmlWebViewSource lesson7;
        public HtmlWebViewSource Lesson7
        {
            get { return lesson7; }
            set { SetProperty(ref lesson7, value); }
        }

        private HtmlWebViewSource lesson8;
        public HtmlWebViewSource Lesson8
        {
            get { return lesson8; }
            set { SetProperty(ref lesson8, value); }
        }
        #endregion

        private List<ScheduleLesson> items;
        public List<ScheduleLesson> Items
        {
            get { return items; }
            set
            {
                items = value;
                Lesson1 = GetHtml(0);
                Lesson2 = GetHtml(1);
                Lesson3 = GetHtml(2);
                Lesson4 = GetHtml(3);
                Lesson5 = GetHtml(4);
                Lesson6 = GetHtml(5);
                Lesson7 = GetHtml(6);
                Lesson8 = GetHtml(7);
            }
        }

        private HtmlWebViewSource GetHtml(int index)
        {
            var source = new HtmlWebViewSource();
            source.Html = items[index].Description;
            return source;
        }
    }
}
