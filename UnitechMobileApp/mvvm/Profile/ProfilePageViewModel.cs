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
        public UserData UserData;
        private ContentPage Page;

        public ProfilePageViewModel(ContentPage page)
        {
            Page = page;
            UserData = Workspace.ActiveUser.GetUserData();
        }
    }
}
