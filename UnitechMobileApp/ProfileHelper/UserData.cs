using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace UnitechMobileApp.ProfileHelper
{
    public class UserData : INotifyPropertyChanged
    {
        private string firstName;
        private string secondName;
        private string thirdName;
        private Xamarin.Forms.ImageSource userAvatar;

        public string FirstName
        {
            get
            {
                return firstName;
            }
            set
            {
                if(firstName != value)
                {
                    firstName = value;
                }
            }
        }

        public string SecondName
        {
            get
            {
                return secondName;
            }
            set
            {
                if (secondName != value)
                {
                    secondName = value;
                }
            }
        }
        public string ThirdName
        {
            get
            {
                return thirdName;
            }
            set
            {
                if (thirdName != value)
                {
                    thirdName = value;
                }
            }
        }

        public Xamarin.Forms.ImageSource UserAvatar
        {
            get
            {
                return userAvatar;
            }
            set
            {
                if (userAvatar != value)
                {
                    userAvatar = value;
                }
            }
        }

        protected void OnPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
