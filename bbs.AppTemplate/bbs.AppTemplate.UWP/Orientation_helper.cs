using bbs.AppTemplate.Globals;
using bbs.AppTemplate.Interfaces;
using Windows.UI.ViewManagement;
using Xamarin.Forms;

[assembly: Dependency(typeof(bbs.AppTemplate.UWP.Orientation_helper))]
namespace bbs.AppTemplate.UWP
{
    public class Orientation_helper : IOrientation_helper
    {
        public Orientations GetCurrentOrientation()
        {
            var orientation = ApplicationView.GetForCurrentView().Orientation;

            if (orientation == ApplicationViewOrientation.Landscape)
                return Orientations.Landscape;
            else if (orientation == ApplicationViewOrientation.Portrait)
                return Orientations.Portrait;
            else
                return Orientations.Undefined;
        }
    }
}
