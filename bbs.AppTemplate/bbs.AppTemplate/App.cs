using bbs.AppTemplate.Globals;
using bbs.AppTemplate.Globals.Settings;
using bbs.AppTemplate.Interfaces;
using bbs.AppTemplate.Models;
using bbs.AppTemplate.Views;
using bbs.AppTemplate.Resources.Langs;

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
        #region SETTINGS
        static AppSettings _settings = null;

        public static AppSettings AppSettings
        {
            get
            {
                if (_settings == null)
                    _settings = new AppSettings();
                return _settings;
            }
        }

        public static List<Property> Settings;
        #endregion

        #region DATABASE
        static DbContext _ctx = null;
        /// <summary>
        /// For each operation into the db you just call this static field (the db class instance)
        /// </summary>
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

        #region ORIENTATION
        /// <summary>
        /// To change dynamically the UI relative to current orientetion, you must override on each page the OnSizeAllocated method (see sample in Home.xaml.cs code)
        /// </summary>
        public static Orientations CurrentOrientation
        {
            get { return DependencyService.Get<IOrientation_helper>().GetCurrentOrientation(); }
        }
        #endregion

        public App()
        {
            #region Local CultureInfo Identifier
            if (Device.RuntimePlatform == Device.iOS || Device.RuntimePlatform == Device.Android)
            {
                var ci = DependencyService.Get<ILocalize_helper>().GetCurrentCulture();
                GlobalResx.Culture = ci; // repeat this for all main resource class
                DependencyService.Get<ILocalize_helper>().SetLocaleCulture(ci);
            }
            #endregion

            MainPage = new NavigationPage(new Home());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
            Settings = AppSettings.GetSettings();
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
            AppSettings.SaveSettingsState();
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
            Settings = AppSettings.GetSettings();
        }
    }
}