using System;
using Android.Graphics;
using Android.Views;
using UnitechMobileApp.mvvm.Profile;
using UnitechMobileApp.Droid.CustomRenders;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Android.Content;

[assembly: ExportRenderer(typeof(CircleImage), typeof(ImageCircleRendererAndroid))]
namespace UnitechMobileApp.Droid.CustomRenders
{
    public class ImageCircleRendererAndroid : ImageRenderer
    {
        public ImageCircleRendererAndroid(Context context) : base(context) { }

        protected override void OnElementChanged(ElementChangedEventArgs<Image> e)
        {
            base.OnElementChanged(e);
            if (e.OldElement == null)
            {
                if ((int)Android.OS.Build.VERSION.SdkInt < 18)
                    SetLayerType(LayerType.Software, null);
            }
        }

        protected override bool DrawChild(Canvas canvas, global::Android.Views.View child, long drawingTime)
        {
            try
            {
                var radius = Math.Min(Width, Height) / 2;
                var strokeWidth = 10;
                radius -= strokeWidth / 2;
                Path path = new Path();
                path.AddCircle(Width / 2, Height / 2, radius, Path.Direction.Ccw);
                canvas.Save();
                canvas.ClipPath(path);
                var result = base.DrawChild(canvas, child, drawingTime);
                canvas.Restore();
                path = new Path();
                path.AddCircle(Width / 2, Height / 2, radius, Path.Direction.Ccw);
                path.Dispose();
                return result;
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
            }
            return base.DrawChild(canvas, child, drawingTime);
        }
    }
}