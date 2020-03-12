using ClientApi;
using Plugin.Settings;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UnitechMobileApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoadPage : ContentPage
    {
        public LoadPage()
        {
            InitializeComponent();
            //todo:
            //ConectionCheck
            var login = CrossSettings.Current.GetValueOrDefault("UserLogin", null);
            var pass = CrossSettings.Current.GetValueOrDefault("UserPassword", null);

            bool result;
            Client.LogIn(login, pass, out result);

            if (result)
            {
                Navigation.PushModalAsync(new MainPage());
            }
            else
            {
                Navigation.PushModalAsync(new AuthPage());
            }
        }
    }
}