using UnitechMobileApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UnitechMobileApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class JournalPage : ContentPage
    {
        JournalViewModel vm;


        public JournalPage()
        {
            InitializeComponent();

            vm = new JournalViewModel(this);

            BindingContext = vm;
        }

    }
}