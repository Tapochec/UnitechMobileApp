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
using ClientApi;

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
            bool authResult;

            Client.LogIn(login, password, out authResult);
            Client.Schedule();
            //Debug.WriteLine(Client.LogIn(login, password, out authResult));
            //Debug.WriteLine("\n\n");
            //Debug.WriteLine(Client.News(0,1));

            string alertText = "Успешно.";
            if (authResult == false)
                alertText = "Не правильное сочетание логина и пароля.";

            DisplayAlert("Alert", alertText, "Ok");
        }
    }
}
