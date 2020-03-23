using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitechMobileApp.mvvm.Profile;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UnitechMobileApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProfilePage : ContentPage
    {
        public ProfilePage()
        {
            InitializeComponent();
            var vm = new ProfilePageViewModel(this);
            BindingContext = vm;
        }
    }
}