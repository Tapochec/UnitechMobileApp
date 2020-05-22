using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitechMobileApp.mvvm.Schedule.Accordion;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UnitechMobileApp.mvvm.Schedule
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SchedulePage : ContentPage
    {
        public SchedulePage()
        {
            InitializeComponent();
            
            var vms = new List<AccordionViewModel>();
            foreach (var item in Accordions.Children)
            {
                vms.Add((item as Accordion.Accordion).ViewModel);
            }
            var vm = new SchedulePageViewModel(this, vms);

            WeekLabel.GestureRecognizers.Add(new TapGestureRecognizer()
            {
                Command = new Command(vm.OpenWeekPickerPage)
            });

            BindingContext = vm;
        }
    }
}