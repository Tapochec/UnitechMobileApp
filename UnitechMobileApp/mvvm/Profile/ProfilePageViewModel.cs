using System;
using System.Collections.Generic;
using System.Text;
using UnitechMobileApp.Model;
using UnitechMobileApp.mvvm.General;
using UnitechMobileApp.ProfileHelper;
using Xamarin.Forms;

namespace UnitechMobileApp.mvvm.Profile
{
    class ProfilePageViewModel : ViewModelBase
    {
        public UserData UserData { get; set; }
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

        public ProfilePageViewModel(ContentPage page)
        {
            Page = page;
            UserData = Workspace.ActiveUser.GetUserData();
            UserData.UserAvatar = Workspace.ActiveUser.GetUserAvatar();
        }

        private Color GetRatingColor(double rating)
        {
            if(rating < 40)
            {
                return Color.FromHex("#dc143c");
            }
            else if(rating < 79.9)
            {
                return Color.FromHex("#ffdf00");
            }
            return Color.FromHex("#61b329");
        }
    }
}
