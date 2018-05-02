using bbs.AppTemplate.Interfaces;
using bbs.AppTemplate.Models;
using bbs.AppTemplate.Views;

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace bbs.AppTemplate
{
    public partial class App : Application
    {
        #region DATABASE
        static DbContext _ctx = null;
        public static DbContext Context
        {
            get
            {
                if (_ctx == null)
                    _ctx = new DbContext(DependencyService.Get<IDbContext_helper>().GetDbPathOnPlatform("bbs.AppTemplateDB.db3"));
                return _ctx;
            }
        }
        #endregion
        public App()
        {
            #region Local CultureInfo Identifier
            if (Device.RuntimePlatform == Device.iOS || Device.RuntimePlatform == Device.Android)
            {
                var ci = DependencyService.Get<ILocalize_helper>().GetCurrentCulture();
                // Langs.Lang.Culture = ci;
                DependencyService.Get<ILocalize_helper>().SetLocaleCulture(ci);
            }
            #endregion

            MainPage = new NavigationPage(new Home());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}