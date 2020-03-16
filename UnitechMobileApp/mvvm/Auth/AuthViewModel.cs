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
        private UserBase user;
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

            Client.Auth(user.Login, user.Password, out result);

            authPage.ShowAuthResultMessage(result);

            if (result)
            {
                CrossSettings.Current.AddOrUpdateValue("UserLogin", user.Login);
                CrossSettings.Current.AddOrUpdateValue("UserPassword", user.Password);
                await authPage.Navigation.PushModalAsync(new MainPage());
            }
        }

        public string Login
        {
            get { return user.Login; }
            set
            {
                if (user.Login != value)
                {
                    user.Login = value;
                    OnPropertyChanged("Login");
                }
            }
        }

        public string Password
        {
            get { return user.Password; }
            set
            {
                if (user.Password != value)
                {
                    user.Password = value;
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
