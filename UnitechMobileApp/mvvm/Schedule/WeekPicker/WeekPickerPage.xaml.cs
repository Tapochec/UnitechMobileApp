using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitechMobileApp.ScheduleHelper;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UnitechMobileApp.mvvm.Schedule.WeekPicker
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WeekPickerPage : ContentPage
    {
        public WeekPickerPage(SchedulePageViewModel scheduleVm)
        {
            InitializeComponent();

            WeekPickerPageViewModel vm = new WeekPickerPageViewModel(scheduleVm);

            LeftArrowImage.Source = ImageSource.FromFile("WhiteArrowLeft.png");
            LeftArrowImage.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(vm.OnLeftArrowTapped),
                NumberOfTapsRequired = 1
            });

            RightArrowImage.Source = ImageSource.FromFile("WhiteArrowRight.png");
            RightArrowImage.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(vm.OnRightArrowTapped),
                NumberOfTapsRequired = 1
            });

            ItemsContainer.ItemSelected += vm.OnWeekSelected;

            BindingContext = vm;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }
    }
}