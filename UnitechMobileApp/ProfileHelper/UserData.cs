using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace UnitechMobileApp.ProfileHelper
{
    public class UserData : INotifyPropertyChanged
    {
        private string firstName;//name
        private string secondName;//patronymic
        private string thirdName;//family
        private Xamarin.Forms.ImageSource userAvatar = Xamarin.Forms.ImageSource.FromFile("stock_people.png");// avatar image
        private double userRating; // user rating
        private string _dateBirth; // user birthday 

        private string facultText; // Институт
        private string specText; // направление
        private string specialization; // специализация
        private string group; // группа
        private string studyStartYear; // год начала обучения
        private string eduPeriod; // продолжительность обучения

        private string email;
        private bool online;
        private string studentHash;

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

        public double Rating
        {
            get
            {
                return userRating;
            }
            set
            {
                if (userRating != value)
                {
                    userRating = value;
                }
            }
        }

        public string BirthDay
        {
            get
            {
                return _dateBirth;
            }
            set
            {
                if (_dateBirth != value)
                {
                    _dateBirth = value;
                }
            }
        }

        public string FacultText
        {
            get
            {
                return facultText;
            }
            set
            {
                if (facultText != value)
                {
                    facultText = value;
                }
            }
        }

        public string SpecText
        {
            get
            {
                return specText;
            }
            set
            {
                if (specText != value)
                {
                    specText = value;
                }
            }
        }

        public string Specialization
        {
            get
            {
                return specialization;
            }
            set
            {
                if (specialization != value)
                {
                    specialization = value;
                }
            }
        }

        public string GroupText
        {
            get
            {
                return group;
            }
            set
            {
                if (group != value)
                {
                    group = value;
                }
            }
        }

        public string StudyStartYear
        {
            get
            {
                return studyStartYear;
            }
            set
            {
                if (studyStartYear != value)
                {
                    studyStartYear = value;
                }
            }
        }

        public string EducationPeriod
        {
            get
            {
                return eduPeriod;
            }
            set
            {
                if (eduPeriod != value)
                {
                    eduPeriod = value;
                }
            }
        }

        public string EMail
        {
            get
            {
                return email;
            }
            set
            {
                if (email != value)
                {
                    email = value;
                }
            }
        }

        public bool Online
        {
            get
            {
                return online;
            }
            set
            {
                if (online != value)
                {
                    online = value;
                }
            }
        }

        public string StudentHash
        {
            get
            {
                return studentHash;
            }
            set
            {
                if (studentHash != value)
                {
                    studentHash = value;
                }
            }
        }

        public bool IsUserSame(UserData other)
        {
            return StudentHash == other.StudentHash;
        }

        //Если не понадобится в будущем, можно удалить
        protected void OnPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
