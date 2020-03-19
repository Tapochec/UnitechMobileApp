using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UnitechMobileApp.mvvm.Schedule.Accordion
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Accordion : ContentView
    {
        #region Title property

        public static readonly BindableProperty TitleBindableProperty = BindableProperty.Create(
            nameof(Title),
            typeof(string),
            typeof(Accordion),
            default(string));

        public string Title
        {
            get
            {
                return (string)GetValue(TitleBindableProperty);
            }
            set
            {
                SetValue(TitleBindableProperty, value);
                TitleLabel.Text = value;
            }
        }

        #endregion

        private const uint animationDuration = 300;
        public bool CanTap { get; private set; } = true;
        public bool Expanded { get; private set; } = false;


        public Accordion()
        {
            InitializeComponent();
            ArrowImage.Source = ImageSource.FromFile("Arrow.png");
            ArrowImage.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(ImageTap),
                NumberOfTapsRequired = 1
            });

            BindingContext = new AccordionViewModel();
        }

        public AccordionViewModel ViewModel => BindingContext as AccordionViewModel;

        private void ImageTap()
        {
            if (!CanTap)
                return;

            CanTap = false;
            if (Expanded)
            {
                Expanded = false;
                Close();
            }
            else
            {
                Expanded = true;
                Open();
            }
        }

        async void Close()
        {
            await Task.WhenAll(
                ItemsContainer.TranslateTo(0, -10, animationDuration),
                ArrowImage.RotateTo(0, animationDuration),
                ItemsContainer.FadeTo(0, 50)
                );
            ItemsContainer.IsVisible = false;
            CanTap = true;
        }

        async void Open()
        {
            ItemsContainer.IsVisible = true;
            await Task.WhenAll(
                ItemsContainer.TranslateTo(0, 10, animationDuration),
                ArrowImage.RotateTo(-180, animationDuration),
                ItemsContainer.FadeTo(30, 50, Easing.SinIn)
            );
            CanTap = true;
        }
    }
}