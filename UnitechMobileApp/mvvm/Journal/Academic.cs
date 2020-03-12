using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace UnitechMobileApp.Models
{
    class Academic
    {
        public string Title {
            get{
                return $"{Semester}\t{SubjText}";
            }
        }


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

        public static List<Academic> JsonToListAcademics(string json) {
            List<Academic> result = JsonConvert.DeserializeObject<List<Academic>>(json);
            return result;
        }

    }
}
