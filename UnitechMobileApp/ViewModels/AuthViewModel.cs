using ClientApi;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using UnitechMobileApp.Models;
using UnitechMobileApp.Models.Commands;
using UnitechMobileApp.Views;

namespace UnitechMobileApp.ViewModels
{
    class AuthViewModel : INotifyPropertyChanged
    {
        private User user;
        public ICommand AuthCommand { get; }
        private readonly AuthPage authPage;

        public event PropertyChangedEventHandler PropertyChanged;

        public AuthViewModel(AuthPage authPage)
        {
            user = new User();
            AuthCommand = new AuthCommand(this);
            this.authPage = authPage;
        }

        public async void Auth()
        {
            bool result;
            Client.LogIn(user.Login, user.Password, out result);

            authPage.ShowAuthResultMessage(result);

            if (result)
                await authPage.Navigation.PopModalAsync();
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
