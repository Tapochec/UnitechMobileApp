using System.IO;
using System.Net;

namespace ClientApi
{
    class Client
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

        static public string LogIn(string login, string password) {
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create($"{domain}&query=AUTH&login={login}&password={password}");
            request.CookieContainer = new CookieContainer();
            string result = "";
            
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse()) {
                if (cookies == null) {
                    cookies = new CookieContainer();
                    cookies.Add(response.Cookies);
                }

                result = ResponseToString(response);
            }

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

        static public string Schedule()
        {
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create($"{domain}&query=SCHEDULE");
            request.CookieContainer = cookies;

            string result = "";

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                result = ResponseToString(response);
            }

            return result;
        }
    }
}
