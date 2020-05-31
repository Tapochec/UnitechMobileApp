using System;
using System.Collections.Generic;
using System.Text;
using UnitechMobileApp.Model;
using UnitechMobileApp.Models;
using UnitechMobileApp.mvvm.General;

namespace UnitechMobileApp.mvvm.Academ
{
    public class AcademViewModel : ViewModelBase
    {
        AcademPage page;

        public string Title
        {
            get
            {
                return $"Дисциплина: {Academic.Title}";
            }
        }

        public string Detail
        {
            get
            {
                return $"Группа: {Academic.Data.GroupText} {Academic.Semester}";
            }
        }



        public IAcademic Academic { get; set; }
        private Subject subject;
        public Subject Subjects
        {
            get
            {
                return subject;
            }
            set
            {
                SetProperty(ref subject, value);
            }
        }

        public AcademViewModel(AcademPage page, IAcademic academic)
        {
            this.page = page;
            Academic = academic;
            Subjects = Subject.formJson(Client.Journal(Academic.Data));
        }


    }
}
