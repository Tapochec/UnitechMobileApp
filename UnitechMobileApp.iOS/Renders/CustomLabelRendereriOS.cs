using CoreGraphics;
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

            if(view.HasShadow)
            {
                Control.ShadowOffset = new CGSize(0, 0.25);
                Control.ShadowColor = UIColor.Gray;
            }
        }
    }
}