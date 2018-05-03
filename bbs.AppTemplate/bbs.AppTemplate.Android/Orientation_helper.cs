using bbs.AppTemplate.Globals;
using bbs.AppTemplate.Interfaces;
using Android.Content;
using Android.Views;
using Java.Interop;
using Xamarin.Forms;

[assembly: Dependency(typeof(bbs.AppTemplate.Droid.Orientation_helper))]
namespace bbs.AppTemplate.Droid
{
    public class Orientation_helper : IOrientation_helper
    {
        public Orientations GetCurrentOrientation()
        {
            IWindowManager windowManager = Android.App.Application.Context.GetSystemService(Context.WindowService).JavaCast<IWindowManager>();
            var orientation = windowManager.DefaultDisplay.Rotation;
            bool isLandscape = orientation == SurfaceOrientation.Rotation90 || orientation == SurfaceOrientation.Rotation270;
            return isLandscape ? Orientations.Landscape: Orientations.Portrait;
        }
    }
}