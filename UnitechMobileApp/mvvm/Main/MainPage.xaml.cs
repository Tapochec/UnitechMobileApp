using System.ComponentModel;
using Xamarin.Forms;

namespace UnitechMobileApp.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : TabbedPage
    {
        public MainPage()
        {
            InitializeComponent();
			
        }
        /// <summary>
        /// Что бы не срабатывала навигация
        /// </summary>
        protected override bool OnBackButtonPressed()
        {
            return false;
        }
    }
}
