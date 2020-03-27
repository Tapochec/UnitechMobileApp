using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;
using UnitechMobileApp.Droid.CustomRenders;
using UnitechMobileApp.mvvm.Profile;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CustomLabel), typeof(CustomLabelRendererAndroid))]
namespace UnitechMobileApp.Droid.CustomRenders
{    
    class CustomLabelRendererAndroid : LabelRenderer
    {
        public CustomLabelRendererAndroid(Context context) : base (context) { }


        protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
        {
            base.OnElementChanged(e);
            var view = (CustomLabel)Element;
            if (view == null) return;  

            if(((CustomLabel)Element).HasShadow)
            {
                Control.SetShadowLayer(4, 0, 2, Android.Graphics.Color.Gray);
            }
        }
    }
}