using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace UnitechMobileApp.mvvm.Profile.AvatarRating
{
    public class CircularProgressBar : View
    {
        //Bindable property for the progress color
        public static readonly BindableProperty ProgressColorProperty = BindableProperty.Create("ProgressColor", typeof(Color), typeof(CircularProgressBar), null);

        //Gets or sets the color of the progress bar
        public Color ProgressColor
        {
            get
            {
                return (Color)GetValue(ProgressColorProperty);
            }
            set 
            {
                SetValue(ProgressColorProperty, value);
            }
        }

    }
}
