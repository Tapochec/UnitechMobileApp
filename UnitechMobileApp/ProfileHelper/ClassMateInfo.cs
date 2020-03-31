using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace UnitechMobileApp.ProfileHelper
{
    public class ClassMateInfo
    {
        private string _firstName;
        private string _secondName;
        private string _thirdName;
        private string _id;
        private string _avatarPath;
        private ImageSource imageSource = ImageSource.FromFile("stock_people.png");
        private bool _online;
        private string _activityDate;

        public string FirstName
        {
            get
            {
                return _firstName;
            }
            set
            {
                if(_firstName != value)
                {
                    _firstName = value;
                }
            }
        }

        public string SecondName
        {
            get
            {
                return _secondName;
            }
            set
            {
                if (_secondName != value)
                {
                    _secondName = value;
                }
            }
        }

        public string ThirdName
        {
            get
            {
                return _thirdName;
            }
            set
            {
                if (_thirdName != value)
                {
                    _thirdName = value;
                }
            }
        }

        public string Id
        {
            get
            {
                return _id;
            }
            set
            {
                if (_id != value)
                {
                    _id = value;
                }
            }
        }

        public string AvatarPath
        {
            get
            {
                return _avatarPath;
            }
            set
            {
                if (_avatarPath != value)
                {
                    _avatarPath = value;
                }
            }
        }

        public ImageSource Avatar
        {
            get
            {
                return imageSource;
            }
            set
            {
                if (imageSource != value)
                {
                    imageSource = value;
                }
            }
        }

        public Color OnlineColor
        {
            get
            {
                return Color.FromHex(Online ? "#12bc00" : "#e3a521");
            }
        }

        public bool Online
        {
            get
            {
                return _online;
            }
            set
            {
                if (_online != value)
                {
                    _online = value;
                }
            }
        }

        public string ActivityDate
        {
            get
            {
                return _activityDate;
            }
            set
            {
                if (_activityDate != value)
                {
                    _activityDate = value;
                }
            }
        }
    }
}
