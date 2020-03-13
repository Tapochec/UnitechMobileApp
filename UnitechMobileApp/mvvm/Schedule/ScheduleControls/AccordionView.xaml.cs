using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UnitechMobileApp.mvvm.Schedule.ScheduleControls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AccordionView : ContentView
    {
        #region Title property

        public static readonly BindableProperty TitleBindableProperty = BindableProperty.Create(
            nameof(Title),
            typeof(string),
            typeof(AccordionView),
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


        public AccordionView()
        {
            InitializeComponent();

            ContentGrid.IsVisible = false;
            ArrowImage.Source = ImageSource.FromFile("Arrow.png");
            ArrowImage.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(ImageTap),
                NumberOfTapsRequired = 1
            });

            //List<string> lessons = new List<string>();
            //for (int i = 0; i < 8; i++)
            //    lessons.Add(@"<strong>ТО-18-1 (ан-1)</strong>, Второй корпус, аудитория 2307 (Бондаренко Тамара Нестеровна - Иностранный язык (второй, профессиональный) - Практическое занятие)<hr/> <strong>ТО-18-1 (ан-2)</strong>, Второй корпус, аудитория 2401 (Когтева Елена Викторовна - Иностранный язык (второй, профессиональный) - Практическое занятие)");

            //Fill(lessons);
        }

        public void Fill(List<string> lessons)
        {
            for (int i = 0; i < 8; i++)
            {
                var htmlSource = new HtmlWebViewSource();
                htmlSource.Html = lessons[i];
                (ContentGrid.Children[i] as WebView).Source = htmlSource;
            }
        }

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
                ContentGrid.TranslateTo(0, -10, animationDuration),
                ArrowImage.RotateTo(0, animationDuration),
                ContentGrid.FadeTo(0, 50)
                );
            ContentGrid.IsVisible = false;
            CanTap = true;
        }

        async void Open()
        {
            ContentGrid.IsVisible = true;
            await Task.WhenAll(
                ContentGrid.TranslateTo(0, 10, animationDuration),
                ArrowImage.RotateTo(-180, animationDuration),
                ContentGrid.FadeTo(30, 50, Easing.SinIn)
            );
            CanTap = true;
        }
    }
}