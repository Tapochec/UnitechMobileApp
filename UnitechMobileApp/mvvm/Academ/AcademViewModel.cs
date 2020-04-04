using System;
using System.Collections.Generic;
using System.Text;
using UnitechMobileApp.Models;
using UnitechMobileApp.mvvm.General;

namespace UnitechMobileApp.mvvm.Academ
{
    public class AcademViewModel : ViewModelBase
    {
        AcademPage page;

        public string Title { get {
                return $"Дисциплина: {Academic.Title}";
            } 
        }

        public string Detail
        {
            get
            {
                return $"Группа: {Academic.Data.GroupText} Семестр: {Academic.Semester}";
            }
        }



        public IAcademic Academic { get; set; }
        public List<SubjectLine> subjectLines { get; set; }

        public AcademViewModel(AcademPage page, IAcademic academic) {
            Academic = academic;
            this.page = page;
        }


    }
}
