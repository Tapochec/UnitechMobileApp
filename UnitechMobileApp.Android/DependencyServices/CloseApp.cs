using Android.OS;
using UnitechMobileApp.DependencyServices;

[assembly: Xamarin.Forms.Dependency(typeof(UnitechMobileApp.Droid.DependencyServices.CloseApp))]
namespace UnitechMobileApp.Droid.DependencyServices
{
    public class CloseApp : ICloseApp
    {
        public void Shutdown()
        {
            Process.KillProcess(Process.MyPid());
        }
    }
}