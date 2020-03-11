using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UnitechMobileApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoadPage : ContentPage
    {
        public LoadPage()
        {
            InitializeComponent();
            //todo:
            //ConectionCheck
            //TryLogin
            Navigation.PushModalAsync(new AuthPage());
            
        }
    }
}