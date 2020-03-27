using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UnitechMobileApp.mvvm.Profile.AvatarRating
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AvatarRating : ContentView
    {
        public static readonly BindableProperty AvatarImageProperty = BindableProperty.Create("AvatarImage", typeof(ImageSource), typeof(AvatarRating), null);

        public static readonly BindableProperty UserRatingProperty = BindableProperty.Create("UserRating", typeof(double), typeof(AvatarRating), null);

        public ImageSource AvatarImage
        {
            get
            {
                return (ImageSource)GetValue(AvatarImageProperty);
            }
            set
            {
                SetValue(AvatarImageProperty, value);
            }
        }

        private double userRating;
        public double UserRating
        {
            get
            {
                return userRating;
            }
            set
            {
                if (userRating != value)
                {
                    userRating = value;
                    OnPropertyChanged("UserRating");
                }
            }
        }

        public AvatarRating()
        {
            InitializeComponent();
            BindingContext = this;
        }

        //todo: use this in the rating border
        public Color GetBlendedColor(int percentage)
        {
            if (percentage < 50)
                return Interpolate(Color.Red, Color.Yellow, percentage / 50.0);
            return Interpolate(Color.Yellow, Color.Lime, (percentage - 50) / 50.0);
        }

        private Color Interpolate(Color color1, Color color2, double fraction)
        {
            double r = Interpolate(color1.R, color2.R, fraction);
            double g = Interpolate(color1.G, color2.G, fraction);
            double b = Interpolate(color1.B, color2.B, fraction);
            return Color.FromRgb((int)Math.Round(r), (int)Math.Round(g), (int)Math.Round(b));
        }

        private double Interpolate(double d1, double d2, double fraction)
        {
            return d1 + (d2 - d1) * fraction;
        }
        //------------------------------
    }
}