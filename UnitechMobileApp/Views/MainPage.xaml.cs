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
using Plugin.Settings;

namespace UnitechMobileApp.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : TabbedPage
    {
        public MainPage()
        {
            InitializeComponent();

            var login = CrossSettings.Current.GetValueOrDefault("UserLogin", null);
            var pass = CrossSettings.Current.GetValueOrDefault("UserPassword", null);

            bool res;
            Client.LogIn(login, pass, out res);

            if (!res)
                Navigation.PushModalAsync(new AuthPage());
        }
    }
}
