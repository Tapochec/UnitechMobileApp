using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UnitechMobileApp.mvvm.Academ
{
    public class People
    {
        public string fio { get; set; }
        public string userid { get; set; }
    }

    public class LessDay
    {
        public string realtime { get; set; }
        public string lesstime { get; set; }
        public string lesstype { get; set; }
        public string comment { get; set; }
    }


    public class Score
    {
        public string userid { get; set; }
        public string lesstime { get; set; }
        public string score { get; set; }
        public string total { get; set; }
        public string type { get; set; }
    }

    public class Weights
    {
        public int auw { get; set; }
        public int atw { get; set; }
        public int lw { get; set; }
    }

    public class Lesson
    {
        public string Title { get {
                return $"{date} : {mark}";
            } 
        }

        public string date { get; set; }
        public string comment { get; set; }
        public string mark { get; set; }
    }

    public class SubjectResults {
        public string sum { get; set; } = "0";
        public string pos { get; set; } = "100";
        public string aud { get; set; } = "100";
        public string att { get; set; } = "0";
        public string itg { get; set; } = "0";
    }

    public class Subject
    {
        public List<People> people_list { get; set; }
        public List<LessDay> lessons_list { get; set; }
        public List<Score> scores_list { get; set; }
        public Weights weights { get; set; }

        public static Subject formJson(string json)
        {
            Subject result = JsonConvert.DeserializeObject<Subject>(json);
            return result;
        }

        public People GetPeople(string id) {
            return people_list.First(x => { return x.userid == id; });
        }

        public List<Lesson> SubjectToLessons(string id) {
            bool find = false;
            people_list.ForEach(x => { if (!find) find = x.userid == id; });
            List<Lesson> result = new List<Lesson>(); 
            if (find) {
                List<Score> UserScores = new List<Score>();

                scores_list.ForEach(x => { if (x.userid == id) UserScores.Add(x); });

                for (int i = 0; i < lessons_list.Count; i++) {
                    string score = "";
                    for (int j = 0; j < UserScores.Count; j++) {
                        if (lessons_list[i].lesstime == UserScores[j].lesstime) {
                            score = scores_list[j].score;
                            break;
                        }
                        
                    }
                    result.Add(new Lesson() { date = lessons_list[i].realtime, mark = score, comment = lessons_list[i].comment });
                }
            }
            return result;
        }

        public SubjectResults Results(string id) {
            SubjectResults result = new SubjectResults();

            //type == old   -> sum
            //type == l     -> pos
            //type == au    -> aud
            //type == at    -> att

            scores_list.ForEach(x => { 
                if (x.userid == id) {
                    if (x.type == "old") result.sum = x.total;
                    if (x.type == "l") result.pos = x.total;
                    if (x.type == "au") result.aud = x.total;
                    if (x.type == "at") result.att = x.total;
                }
            }
            );
            result.itg = ((Convert.ToInt32(result.pos) * weights.lw + Convert.ToInt32(result.aud) * weights.auw + Convert.ToInt32(result.att) * weights.atw)/100).ToString();
            return result;
        }
    }
}
