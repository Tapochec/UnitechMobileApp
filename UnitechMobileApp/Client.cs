using System;
using System.Collections.Generic;
using System.IO;
using System.Net;

namespace ClientApi
{
    static class Client
    {
        static string domain = "https://ies.unitech-mo.ru/api?token=e78a4a9c0b16dd06b0ebc4748345a144";
        static CookieContainer cookies = null;

        static string ResponseToString(HttpWebResponse response) {
            string result = "";

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
            return result;
        }

        static public string LogIn(string login, string password, out bool authResult) {
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create($"{domain}&query=AUTH&login={login}&password={password}");
            request.CookieContainer = new CookieContainer();
            string result = "";
            
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse()) {
                //cookies.Add(response.Cookies);

                if (cookies == null)
                {
                    cookies = new CookieContainer();
                    cookies.Add(response.Cookies);
                }

                result = ResponseToString(response);
            }

            authResult = result != "null";

            return result;
        }


        static public string News(int offset, int limit) {
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create($"{domain}&query=NEWS&offset={offset}&limit={limit}");
            request.CookieContainer = cookies;

            string result = "";

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                result = ResponseToString(response);
            }

            return result;
        }

        // Возращает расписание на текущую неделю
        public static string Schedule()
        {
            HttpWebRequest request = CreateRequest("SCHEDULE", null);
            request.CookieContainer = cookies;

            string result = "";

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                result = ResponseToString(response);
            }

            return "not implemented";
        }

        public static string Schedule(DateTime from, DateTime to)
        {
            throw new NotImplementedException();
        }

        private static HttpWebRequest CreateRequest(string queryName, Dictionary<string, string> paramValuePairs)
        {
            string paramsString = "";

            if (paramValuePairs != null)
            {
                foreach (var pair in paramValuePairs)
                {
                    paramsString += $"&{pair.Key}={pair.Value}";
                }
            }

            string requestString = $"{domain}&query={queryName}{paramsString}";

            HttpWebRequest request = WebRequest.Create(requestString) as HttpWebRequest;

            return request;
        }
    }
}
