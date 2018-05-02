using bbs.AppTemplate.Interfaces;
using bbs.AppTemplate.Services;
using Foundation;
using System;
using System.Diagnostics;
using System.Globalization;
using System.Threading;
using Xamarin.Forms;

[assembly: Dependency(typeof(bbs.AppTemplate.iOS.Localize))]
namespace bbs.AppTemplate.iOS
{
    public class Localize : ILocalize_helper
    {
        public CultureInfo GetCurrentCulture()
        {
            var netLanguage = "it";
            if (NSLocale.PreferredLanguages.Length > 0)
            {
                var pref = NSLocale.PreferredLanguages[0];
                netLanguage = iOSToDotNetLanguage(pref);
            }

            CultureInfo ci = null;
            try
            {
                ci = new CultureInfo(netLanguage);
            }
            catch (CultureNotFoundException e1)
            {
                try
                {
                    var fallback = ToDotnetFallbackLanguage(new PlatformCulture_service(netLanguage));
                    ci = new CultureInfo(fallback);
                    Debug.Write(e1.Message);
                }
                catch (CultureNotFoundException e2)
                {
                    ci = new CultureInfo("it");
                    Debug.Write(e2.Message);
                }
            }
            catch (Exception ex)
            {
                ci = new CultureInfo("it");
                Debug.Write(ex.Message);
            }
            return ci;
        }

        public void SetLocaleCulture(CultureInfo cultureInfo)
        {
            Thread.CurrentThread.CurrentCulture = cultureInfo;
            Thread.CurrentThread.CurrentUICulture = cultureInfo;
        }

        string iOSToDotNetLanguage(string iOSLang)
        {
            var netLanguage = iOSLang;

            switch (iOSLang)
            {
                case "ms-BN":   // "Malaysian (Brunei)" not supported .NET culture
                case "ms-MY":   // "Malaysian (Malaysia)" not supported .NET culture
                case "ms-SG":   // "Malaysian (Singapore)" not supported .NET culture
                    netLanguage = "ms"; // closest supported
                    break;
                case "in-ID":  // "Indonesian (Indonesia)" has different code in  .NET
                    netLanguage = "id-ID"; // correct code for .NET
                    break;
                case "gsw-CH":  // "Schwiizertüütsch (Swiss German)" not supported .NET culture
                    netLanguage = "de-CH"; // closest supported
                    break;
            }
            return netLanguage;
        }

        string ToDotnetFallbackLanguage(PlatformCulture_service platformCulture)
        {
            var netLanguage = platformCulture.LanguageCode;
            switch (platformCulture.LanguageCode)
            {
                case "gsw":
                    netLanguage = "de-CH"; // equivalent to German (Switzerland) for this app
                    break;
            }
            return netLanguage;
        }
    }
}
