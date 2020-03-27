using System;
using System.ComponentModel;
using UnitechMobileApp.iOS.CustomRenderers;
using UnitechMobileApp.mvvm.Profile;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(CircleImage), typeof(ImageCircleRenderer))]
namespace UnitechMobileApp.iOS.CustomRenderers
{
    public class ImageCircleRenderer : ImageRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Image> e)
        {
            base.OnElementChanged(e);
            if (e.OldElement != null || Element == null) return;
            CreateCircle();
        }
        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            if (e.PropertyName == VisualElement.HeightProperty.PropertyName || e.PropertyName == VisualElement.WidthProperty.PropertyName)
            {
                CreateCircle();
            }
        }
        private void CreateCircle()
        {
            try
            {
                double min = Math.Min(Element.Width, Element.Height);
                Control.Layer.CornerRadius = (float)(min / 2.0);
                Control.Layer.MasksToBounds = false;
                Control.Layer.BorderColor = Color.White.ToCGColor();
                Control.Layer.BorderWidth = 1;
                Control.ClipsToBounds = true;
            }
            catch (Exception ex)
            {
                
            }
        }
    }
}