using System;
using Android.Graphics;
using Android.Views;
using UnitechMobileApp.mvvm.Profile;
using UnitechMobileApp.Droid.CustomRenders;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Android.Content;
using Android.Widget;
using Android.Graphics.Drawables;
using System.IO;

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
            //BitmapDrawable bd = (BitmapDrawable)((ImageView)child).Drawable; // invalid cast exception, cant find solution in google.com
            //MemoryStream ms = new MemoryStream();
            //bd.Bitmap.Compress(Bitmap.CompressFormat.Jpeg, 50, ms);
            //((ImageView)child).SetImageDrawable(Drawable.CreateFromStream(ms, ""));
            try
            {
                var radius = Math.Min(Width, Height) / 2;
                var strokeWidth = 10;
                radius -= strokeWidth / 2;
                Android.Graphics.Path path = new Android.Graphics.Path();
                path.AddCircle(Width / 2, Height / 2, radius, Android.Graphics.Path.Direction.Ccw);
                canvas.Save();
                canvas.ClipPath(path);
                var result = base.DrawChild(canvas, child, drawingTime);
                canvas.Restore();
                path = new Android.Graphics.Path();
                path.AddCircle(Width / 2, Height / 2, radius, Android.Graphics.Path.Direction.Ccw);
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