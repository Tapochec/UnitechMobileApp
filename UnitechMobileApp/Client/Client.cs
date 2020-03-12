using System.IO;
using System.Net;

namespace ClientApi
{
    class Client
    {
        static string domain = "https://ies.unitech-mo.ru/api?token=e78a4a9c0b16dd06b0ebc4748345a144";
        static CookieContainer cookies = null;

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
                        string line = "";
                        while ((line = reader.ReadLine()) != null)
                        {
                            result += line;
                        }
                    }
                }
                response.Close();
            }
            return result;
        }


        /// <summary>
        /// Метод логинит в API unitech-mo и запоминает нужные Cookies
        /// </summary>
        /// <param name="login"></param>
        /// <param name="password"></param>
        /// <returns> Json строку при удачной аутентификации и "null" при неудаче</returns>
        static public string LogIn(string login, string password, out bool authResult)
        {
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create($"{domain}&query=AUTH&login={login}&password={password}");
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
                        string line = "";
                        while ((line = reader.ReadLine()) != null)
                        {
                            result += line;
                        }
                    }
                }
                response.Close();

                authResult = result != "null";
            }

            authResult = !(result == "null");

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
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create($"{domain}&query=NEWS&offset={offset}&limit={limit}");
            request.CookieContainer = cookies;

            return FillRequest(request);

        }

        /// <summary>
        /// Метод берет расписание залогиненного пользователя с API unitech-mo
        /// </summary>
        /// <returns>Json с расписанием</returns>
        static public string Schedule()
        {
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create($"{domain}&query=SCHEDULE");
            request.CookieContainer = cookies;

            return FillRequest(request);
        }

        /// <summary>
        /// Метод берет учебный план залогиненного пользователя с API unitech-mo
        /// </summary>
        /// <returns>Json с учебным планом</returns>
        static public string StudentPlan()
        {
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create($"{domain}&query=STUDENT_PLAN");
            request.CookieContainer = cookies;

            return FillRequest(request);
        }
    }
}
