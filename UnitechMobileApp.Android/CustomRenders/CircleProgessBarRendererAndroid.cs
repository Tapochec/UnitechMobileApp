using Android.Content;
using UnitechMobileApp.Droid.CustomRenders;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using UnitechMobileApp.mvvm.Profile.AvatarRating;
using Android.Graphics;
using Java.Lang;

[assembly: ExportRenderer(typeof(CircularProgressBar), typeof(CircleProgessBarRenderer))]
namespace UnitechMobileApp.Droid.CustomRenders
{
    class CircleProgessBarRenderer : ProgressBarRenderer
    {
        private Context context;
        public CircleProgessBarRenderer(Context context) : base(context)
        {
            this.context = context;
        }

        protected override void OnDraw(Canvas canvas)
        {
            var radius = Math.Min(Width, Height) / 2;


            Path path = new Path();
            path.AddCircle(Width / 2, Height / 2, radius, Path.Direction.Ccw);
            canvas.Save();
            canvas.ClipPath(path);
            canvas.Restore();
            path = new Path();
            path.AddCircle(Width / 2, Height / 2, radius, Path.Direction.Ccw);
            
            path.Dispose();
        }
    }
}