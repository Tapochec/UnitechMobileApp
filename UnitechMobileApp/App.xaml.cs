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

            MainPage = new NavigationPage(new LoadPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
