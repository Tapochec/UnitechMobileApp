using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using ClientApi;
using Plugin.Settings;

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
