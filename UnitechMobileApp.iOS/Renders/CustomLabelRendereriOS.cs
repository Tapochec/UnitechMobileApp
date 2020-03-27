using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoreGraphics;
using Foundation;
using UIKit;
using UnitechMobileApp.iOS.Renders;
using UnitechMobileApp.mvvm.Profile;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(CustomLabel), typeof(CustomLabelRendereriOS))]
namespace UnitechMobileApp.iOS.Renders
{
    public class CustomLabelRendereriOS : LabelRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
        {
            base.OnElementChanged(e);

            var view = (CustomLabel)Element;
            if (view == null) return;

            // Adding the Button text shadow effect
            //Control.TitleLabel.ShadowOffset = new CGSize(0, 0.25);
            
            //if (((CustomLabel)Element).HasShadow)
            //{
            //    Control.
           // }
            //Control.SetTitleShadowColor(((CustomLabel)Element).TextShadowColor.ToUIColor(), UIControlState.Normal);
        }
    }
}