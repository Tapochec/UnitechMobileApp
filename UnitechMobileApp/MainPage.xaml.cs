using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace UnitechMobileApp
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            string login = LoginInput.Text;
            string password = PasswordInput.Text;

            string requestText = "https://ies.unitech-mo.ru/api?token=e78a4a9c0b16dd06b0ebc4748345a144&query=AUTH&" + 
                $"login={login}&password={password}";

            WebRequest request = WebRequest.Create(requestText);
            request.Method = "POST";

            WebResponse response = request.GetResponse();

            using (Stream stream = response.GetResponseStream())
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    string line = "";
                    while ((line = reader.ReadLine()) != null)
                    {
                        Debug.WriteLine(line);
                    }
                }
            }
            response.Close();
        }
    }
}
