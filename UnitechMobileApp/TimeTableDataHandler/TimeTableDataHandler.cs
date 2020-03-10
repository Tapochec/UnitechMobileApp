using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace TimeTable
{
    public class DataTimeTableData
    {
        public List<TimeTableDay> data;
        public List<TimeTableDay> holydays;
    }

    public class TimeTableDay
    {
        public int daynum;
        public int timenum; // номер пары
        public int weeknum; // 1 - чётная, 2 - не чётнаяб 3 - по обеим
        public string lparam;
        public string note;
    }


    /// <summary>
    /// Принимает на вход json и парсит его в объект. Пары, которые выпали на праздничный день, заменяются на праздник
    /// </summary>
    class TimeTableDataHandler
    {
        public static DataTimeTableData Data;

        public static void JsonToTimeTableData(string rawData)
        {
            var a = JsonConvert.DeserializeObject<DataTimeTableData>(rawData);

            //filtering data from holidays
            foreach(var item in a.holydays)
            {
                for(int i = 0; i < a.data.Count; ++i)
                {
                    if(a.data[i].daynum == item.daynum)
                    {
                        a.data[i] = item;
                    }
                }
            }
            Data = a;
        }
    }
}
