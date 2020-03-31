﻿using UnitechMobileApp.mvvm.Profile;
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

        private void TapGestureRecognizer_Tapped(object sender, System.EventArgs e)
        {
            //через команду сделать не смог
            ((ProfilePageViewModel)BindingContext).Tapped((CircleImage)sender);
        }
    }
}