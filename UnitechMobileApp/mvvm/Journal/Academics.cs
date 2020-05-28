using System;
using System.Collections.Generic;
using System.Text;

namespace UnitechMobileApp.Models
{
    public class TeacherAcademic : IAcademic
    {

        public string Semester
        {
            get
            {
                return $"";
            }
        }

        public string Title
        {
            get
            {
                return Data.SubjText;
            }
        }
        public string Detail
        {
            get
            {
                return Data.GroupText;
            }
        }
        public AcademicData Data { get; set; }
    }

    public class StudentAcademic : IAcademic
    {
        public string Semester
        {
            get
            {
                return $"Семестр: {Data.Semester}";
            }
        }

        public string Title
        {
            get
            {
                return Data.SubjText;
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
