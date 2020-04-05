using System.Collections.Generic;
using System.Windows.Input;
using UnitechMobileApp.Model;
using UnitechMobileApp.mvvm.General;
using UnitechMobileApp.ProfileHelper;
using UnitechMobileApp.Views;
using Xamarin.Forms;

namespace UnitechMobileApp.mvvm.Profile
{
    class ProfilePageViewModel : ViewModelBase
    {
        public UserData UserData
        {
            get
            {
                return onLoginedUser ? activeUser : selectedClassMate;
            }
            set
            {
                if(onLoginedUser)
                {
                    SetProperty(ref activeUser, value);
                }
                else
                {
                    SetProperty(ref selectedClassMate, value);
                }
            }
        }

        public UserData activeUser; // for logined user
        public UserData selectedClassMate; // for selected classmate
        bool onLoginedUser = true; //boolean flag that indicates, that the user is on own profile

        public bool OnLoginedUser
        {
            get
            {
                return onLoginedUser;
            }
            set
            {
                SetProperty(ref onLoginedUser, value);
            }
        }

        public Color OnlineColor
        {
            get
            {
                return GetOnlineColor(UserData.Online);
            }
        }

        private Color GetOnlineColor(bool online)
        {
            return Color.FromHex(online ? "#12bc00" : "#e3a521");
        }

        private List<ClassMateInfo> _classMates;
        public List<ClassMateInfo> ClassMates
        {
            get
            {
                return _classMates;
            }
            set
            {
                SetProperty(ref _classMates, value);
            }
        }
        private ContentPage Page;

        public double RatingProgress
        {
            get
            {
                return UserData.Rating / 100;
            }
        }

        public Color ProgressBarColor
        {
            get
            {
                return GetRatingColor(UserData.Rating);
            }
        }

        private Color GetRatingColor(double rating)
        {
            if (rating < 40)
            {
                return Color.FromHex("#dc143c");
            }
            else if (rating < 79.9)
            {
                return Color.FromHex("#ffdf00");
            }
            return Color.FromHex("#61b329");
        }

        public ICommand TapCommand { private set; get; }

        public ProfilePageViewModel(ContentPage page)
        {
            Page = page;
            activeUser = Workspace.ActiveUser.GetUserData();
            UserData = activeUser;
            TapCommand = new ClassmateTapComand(this);
            FillClassMates();
        }

        public void Refresh()
        {
            OnPropertyChanged("UserData");
            OnPropertyChanged("RatingProgress");
            OnPropertyChanged("OnlineColor");
            OnPropertyChanged("ProgressBarColor");
            OnPropertyChanged("ClassMates");
            ((ProfilePage)Page).ScrollToTop();
        }

        private void FillClassMates()
        {
            var classMateList = Workspace.ActiveUser.GetUserClassMates();
            ClassMates = classMateList;
        }
    }
}
