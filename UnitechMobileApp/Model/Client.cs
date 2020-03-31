using System;
using System.IO;
using System.Net;

namespace UnitechMobileApp.Model
{
    public static class Client
    {
        static string domain = "https://ies.unitech-mo.ru";
        static string token = "/api?token=e78a4a9c0b16dd06b0ebc4748345a144";
        static CookieContainer cookies = null;
        private static bool isFirstAuth = true;        

        /// <summary>
        /// метод выполняет request и возвращает строку полученную из него
        /// </summary>
        static string FillRequest(HttpWebRequest request)
        {
            string result = "";

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                using (Stream stream = response.GetResponseStream())
                {
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        result = reader.ReadToEnd();
                    }
                }
            }
            return result;
        }


        /// <summary>
        /// Метод логинит в API unitech-mo и запоминает нужные Cookies
        /// </summary>
        /// <param name="login"></param>
        /// <param name="password"></param>
        /// <returns> Json строку при удачной аутентификации и "null" при неудаче</returns>
        static public string Auth(string login, string password, out bool authResult)
        {
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create($"{domain}{token}&query=AUTH&login={login}&password={password}");
            request.CookieContainer = new CookieContainer();
            string result = "";

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                cookies = new CookieContainer();
                cookies.Add(response.Cookies);

                using (Stream stream = response.GetResponseStream())
                {
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        result = reader.ReadToEnd();
                    }
                }
            }
            authResult = result != "null";

            if (isFirstAuth)
            {
                if (authResult)
                    Workspace.SetUserActive(result);

                isFirstAuth = false;
            }

            return result;
        }

        /// <summary>
        /// Метод берет новости с API unitech-mo
        /// </summary>
        /// <param name="offset">Смещение относительно последней новости</param>
        /// <param name="limit">Количестов новостей которые нужно взять (0 - все)</param>
        /// <returns>Html с текстом новостей </returns>
        static public string News(int offset = 0, int limit = 1)
        {
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create($"{domain}{token}&query=NEWS&offset={offset}&limit={limit}");
            request.CookieContainer = cookies;

            return FillRequest(request);

        }

        /// <summary>
        /// Метод берет расписание этой недели залогиненного пользователя с API unitech-mo
        /// </summary>
        /// <returns>Json с расписанием</returns>
        static public string Schedule()
        {
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create($"{domain}{token}&query=SCHEDULE");
            request.CookieContainer = cookies;

            return FillRequest(request);
        }

        /// <summary>
        /// Метод берет расписание залогиненного пользователя с выбранной недели через API unitech-mo
        /// </summary>
        /// <returns>Json с расписанием</returns>
        static public string Schedule(DateTime begdate, DateTime enddate, out bool sucses)
        {
            sucses = false;
            string result = null;

            if ((begdate.DayOfWeek == DayOfWeek.Monday && enddate.DayOfWeek == DayOfWeek.Sunday) 
                && ((enddate - begdate).TotalDays == 6))
            {
                sucses = true;

                HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create($"{domain}{token}&query=SCHEDULE&d={begdate.ToShortDateString()}-{enddate.ToShortDateString()}");
                request.CookieContainer = cookies;
                
                result = FillRequest(request);
            }

            return result;
        }

        /// <summary>
        /// Метод берет учебный план залогиненного пользователя с API unitech-mo
        /// </summary>
        /// <returns>Json с учебным планом</returns>
        static public string StudentPlan()
        {
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create($"{domain}{token}&query=STUDENT_PLAN");
            request.CookieContainer = cookies;

            return FillRequest(request);
        }

        /// <summary>
        /// Метод получает информацию о залогиненом пользователе с API unitech-mo
        /// </summary>
        /// <returns>Json-строку с информацией о пользователе</returns>
        static public string UserData()
        {            
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create($"{domain}{token}&query=USER_DATA&id={Workspace.ActiveUser.id}");
            request.CookieContainer = cookies;
            return FillRequest(request);
        }

        /// <summary>
        /// Метод получает информацию о пользователе с API unitech-mo
        /// </summary>
        /// <param name="userID">id пользоватля, информацию о котором надо получить</param>
        /// <returns>Json-строку с информацией о пользователе</returns>
        static public string UserData(string userID = "-1")
        {
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create($"{domain}{token}&query=USER_DATA&id={userID}");
            request.CookieContainer = cookies;
            return FillRequest(request);
        }

        /// <summary>
        /// Метод получает аватар пользователя в виде массива байтов с unitech-mo
        /// </summary>
        /// <returns>ImageSource, в котором хранится аватар пользователя</returns>
        static public Xamarin.Forms.ImageSource Avatar()
        {
            Xamarin.Forms.ImageSource toReturn = null;
            using (WebClient webClient = new WebClient())
            {                
                try
                {
                    //Getting avatar image as byte array
                    byte[] data = webClient.DownloadData($"{domain}/img/avatar/{Workspace.ActiveUser.id}/{Workspace.ActiveUser.avatarPath}");
                    toReturn = Xamarin.Forms.ImageSource.FromStream(() => new MemoryStream(data));
                }
                //If the user didn't set avatar to his profile WebException will thrown
                catch (WebException e)
                {
                    toReturn = Xamarin.Forms.ImageSource.FromFile("stock_people.png");
                }
            }
            return toReturn;
        }

        /// <summary>
        /// Метод получает аватар пользователя в виде массива байтов с unitech-mo
        /// </summary>
        /// <param name="id">Id пользователя</param>
        /// <param name="avatar">Название аватара</param>
        /// <returns>ImageSource, в котором хранится аватар пользователя</returns>
        static public Xamarin.Forms.ImageSource Avatar(string id, string avatar)
        {
            Xamarin.Forms.ImageSource toReturn = null;
            using (WebClient webClient = new WebClient())
            {
                try
                {
                    //Getting avatar image as byte array
                    byte[] data = webClient.DownloadData($"{domain}/img/avatar/{id}/{avatar}");
                    toReturn = Xamarin.Forms.ImageSource.FromStream(() => new MemoryStream(data));
                }
                //If the user didn't set avatar to his profile WebException will thrown
                catch (WebException e)
                {
                    toReturn = Xamarin.Forms.ImageSource.FromFile("stock_people.png");
                }
            }
            return toReturn;
        }

        /// <summary>
        /// Метод получает список одногруппников пользователя с API unitech-mo
        /// </summary>
        /// <returns>Json-строку с списком одногруппников пользователя</returns>
        static public string UserClassMate()
        {
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create($"{domain}{token}&query=USER_CLASSMATE&id={Workspace.ActiveUser.id}");
            request.CookieContainer = cookies;
            return FillRequest(request);
        }

        /// <summary>
        /// Метод получает список одногруппников пользователя с API unitech-mo
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        static public string UserClassMate(string id)
        {
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create($"{domain}{token}&query=USER_CLASSMATE&id={id}");
            request.CookieContainer = cookies;
            return FillRequest(request);
        }
    }
}
