using System;
using System.Collections.Generic;
using System.Text;

namespace UnitechMobileApp.mvvm.Academ
{
    public class SubjectLine
    {
        string fio { get; set; }
        List<string> mark { get; set; }
        //Сум.Пос.Ауд.Атт.Итог
        double Sum { get; set; }
        double Attendance { get; set; }
        double Ayd { get; set; }
        double Att { get; set; }
        double Resule { get; set; }
    }
}
