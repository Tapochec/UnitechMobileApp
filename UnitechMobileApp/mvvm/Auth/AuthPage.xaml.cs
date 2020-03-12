using Plugin.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitechMobileApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UnitechMobileApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AuthPage : ContentPage
    {
        public AuthPage()
        {
            InitializeComponent();
            
            AuthViewModel vm = new AuthViewModel(this)
            {
#if DEBUG
                Login = "petrenkoas",
                Password = "12345"
#endif
            };           
            BindingContext = vm;
        }

        

        public async void ShowAuthResultMessage(bool authResult)
        {
            string text = "Успешно.";

            if (authResult == false)
                text = "Неверное сочетание логина и пароля.";

            await DisplayAlert("Вход", text, "Ок");
        }
    }
}