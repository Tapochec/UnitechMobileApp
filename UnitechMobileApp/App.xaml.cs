using ClientApi;
using Plugin.Settings;
using System;
using UnitechMobileApp.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UnitechMobileApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
            //var login = CrossSettings.Current.GetValueOrDefault("UserLogin", null);
            //var pass = CrossSettings.Current.GetValueOrDefault("UserPassword", null);

            //if (login != null && pass != null)
            //{
                
            //}
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
