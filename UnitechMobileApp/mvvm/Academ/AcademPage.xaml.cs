using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitechMobileApp.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UnitechMobileApp.mvvm.Academ
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AcademPage : ContentPage
    {
        AcademViewModel vm;

        public AcademPage(IAcademic academic)
        {
            vm = new AcademViewModel(this, academic);
            InitializeComponent();
            BindingContext = vm;
        }
    }
}