using System.Threading;
using UnitechMobileApp.DependencyServices;

[assembly: Xamarin.Forms.Dependency(typeof(UnitechMobileApp.iOS.DependencyServices.CloseApp))]
namespace UnitechMobileApp.iOS.DependencyServices
{
    class CloseApp : ICloseApp
    {
        public void Shutdown()
        {
            Thread.CurrentThread.Abort();
        }
    }
}