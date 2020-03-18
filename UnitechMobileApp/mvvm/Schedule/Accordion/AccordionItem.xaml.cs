using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UnitechMobileApp.mvvm.Schedule.Accordion
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AccordionItem : ContentView
    {
        #region Number property

        public static readonly BindableProperty NumberBindableProperty = BindableProperty.Create(
            nameof(Number),
            typeof(string),
            typeof(AccordionItem),
            default(string));

        public string Number
        {
            get
            {
                return (string)GetValue(NumberBindableProperty);
            }
            set
            {
                SetValue(NumberBindableProperty, value);
                NumberLabel.Text = value;
            }
        }

        #endregion

        #region WebViewSource property

        public static readonly BindableProperty WebViewSourceBindableProperty = BindableProperty.Create(
            nameof(WebViewSource),
            typeof(HtmlWebViewSource),
            typeof(AccordionItem),
            default(HtmlWebViewSource));

        public HtmlWebViewSource WebViewSource
        {
            get
            {
                return (HtmlWebViewSource)GetValue(WebViewSourceBindableProperty);
            }
            set
            {
                SetValue(WebViewSourceBindableProperty, value);
                DescriptionWebView.Source = value;
            }
        }

        #endregion

        public AccordionItem()
        {
            InitializeComponent();
        }
    }
}