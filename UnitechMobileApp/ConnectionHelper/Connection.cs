using Plugin.Connectivity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace UnitechMobileApp.ConnectionHelper
{
    public static class Connection
    {
        /// <summary>
        /// Данный метод проверяет наличие подключения
        /// </summary>
        /// <param name="host">Адрес хоста, соединение к которому нужно проверить (по умолчанию пингует DNS-сервер Google)</param>
        /// <returns>true, если подключение есть, false если подключение отсутствует</returns>  
        public static async Task<bool> IsAvailable(string host = "8.8.8.8")
        {
            if (CrossConnectivity.Current != null &&
                CrossConnectivity.Current.ConnectionTypes != null &&
                CrossConnectivity.Current.IsConnected)                
            {                 
                return await CrossConnectivity.Current.IsRemoteReachable(host);
            }
            return false;
        }
    }
}
