﻿using System;
using System.Collections.Generic;
using System.Text;
using UnitechMobileApp.ScheduleHelper;
using UnitechMobileApp.Models;
using Newtonsoft.Json;

namespace UnitechMobileApp.Model
{
    public class StudentBehavior : UserBase
    {
        override public List<IAcademic> JsonToListAcademics(string json)
        {
            List<AcademicData> academicDatas = JsonConvert.DeserializeObject<List<AcademicData>>(json);
            List<IAcademic> result = new List<IAcademic>();

            foreach (var i in academicDatas) {
                result.Add(new StudentAcademic() { Data = i });
            }

            return result;
        }
    }
}
