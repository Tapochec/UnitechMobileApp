using Plugin.Settings;
using System.ComponentModel;
using System.Windows.Input;
using UnitechMobileApp.Model;
using UnitechMobileApp.Models;
using UnitechMobileApp.Views;
using Xamarin.Forms;

namespace UnitechMobileApp.ViewModels
{
    class AuthViewModel : INotifyPropertyChanged
    {
        public ICommand AuthCommand { get; }
        private readonly AuthPage authPage;

        public event PropertyChangedEventHandler PropertyChanged;

        public AuthViewModel(AuthPage authPage)
        {
            AuthCommand = new Command(Auth);
            this.authPage = authPage;
        }

        public async void Auth()
        {
            bool result;

            Client.Auth(Login, Password, out result);

            authPage.ShowAuthResultMessage(result);

            if (result)
            {
                CrossSettings.Current.AddOrUpdateValue("UserLogin", Login);
                CrossSettings.Current.AddOrUpdateValue("UserPassword", Password);
                await authPage.Navigation.PushModalAsync(new MainPage());
            }
        }

        private string login;
        public string Login
        {
            get { return login; }
            set
            {
                if (login != value)
                {
                    login = value;
                    OnPropertyChanged("Login");
                }
            }
        }

        private string password;
        public string Password
        {
            get { return password; }
            set
            {
                if (password != value)
                {
                    password = value;
                    OnPropertyChanged("Password");
                }
            }
        }

        protected void OnPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }
}
