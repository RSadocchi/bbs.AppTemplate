using bbs.AppTemplate.Globals;
using bbs.AppTemplate.Interfaces;
using bbs.AppTemplate.Models;
using bbs.AppTemplate.Views;
using bbs.AppTemplate.Resources.Langs;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace bbs.AppTemplate.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Home : ContentPage
	{
		public Home ()
		{
			InitializeComponent ();
            UILabel.Text = GlobalResx.Hello;
		}

        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);
            var orientation = App.CurrentOrientation;
            switch (orientation)
            {
                case Orientations.Landscape:
                    // TO DO: your UI action
                    // for example:
                    // UILabel.FontSize = App.CurrentOrientation.GetOrientationFontSize().Large;
                    break;

                case Orientations.Portrait:
                    // TO DO: your UI action
                    break;

                case Orientations.Undefined:
                    // TO DO: your UI action
                    break;

                default:
                    // TO DO: your UI action
                    break;
            }
        }
    }
}