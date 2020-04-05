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

        public void ScrollToTop()
        {
            scroll.ScrollToAsync(0, 0, false);
        }
    }
}