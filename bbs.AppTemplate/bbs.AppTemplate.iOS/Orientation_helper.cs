using bbs.AppTemplate.Globals;
using bbs.AppTemplate.Interfaces;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(bbs.AppTemplate.iOS.Orientation_helper))]
namespace bbs.AppTemplate.iOS
{
    public class Orientation_helper : IOrientation_helper
    {
        public Orientations GetCurrentOrientation()
        {
            var orientation = UIApplication.SharedApplication.StatusBarOrientation;
            bool isPortrait = orientation == UIInterfaceOrientation.Portrait || orientation == UIInterfaceOrientation.PortraitUpsideDown;
            return (isPortrait ? Orientations.Portrait : Orientations.Landscape);
        }
    }
}
