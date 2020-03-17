using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace UnitechMobileApp.Models
{
    public class AcademicData
    {
        public string SubjText { get; set; }

        public int Semester { get; set; }
        public int SubjCode { get; set; }
        public string GroupText { get; set; }
        public int MarkTypeCode { get; set; }
        public string MarkTypeText { get; set; }
        public int YearInUcPlan { get; set; }

        public int pin { get; set; }
        public string mc { get; set; }

        public string pres { get; set; }
        public int pres2 { get; set; }

        public string tutor { get; set; }
        public string lesson { get; set; }
    }

    public interface IAcademic
    {
        string Title { get; }
        string Detail { get; }
        AcademicData Data { get; set; }
    }

    public class TeacherAcademic : IAcademic {
        public string Title { 
            get 
            {
                return $"{Data.Semester}\t{Data.SubjText}";
            }
        }
        public string Detail { 
            get 
            {
                return Data.GroupText;
            } 
        }
        public AcademicData Data { get; set; }
    }

    public class StudentAcademic : IAcademic
    {
        public string Title
        {
            get
            {
                return $"{Data.Semester}\t{Data.SubjText}";
            }
        }
        public string Detail
        {
            get
            {
                return Data.tutor;
            }
        }
        public AcademicData Data { get; set; }
    }

}
