using bbs.AppTemplate.Interfaces;
using bbs.AppTemplate.Services;
using System.Globalization;
using System.Threading;
using Xamarin.Forms;

[assembly: Dependency(typeof(bbs.AppTemplate.Droid.Localize))]
namespace bbs.AppTemplate.Droid
{
    public class Localize : ILocalize_helper
    {
        public CultureInfo GetCurrentCulture()
        {
            var netLanguage = "it";
            var androidLocale = Java.Util.Locale.Default;
            netLanguage = DroidToDotNetLanguage(androidLocale.ToString().Replace("_", "-"));
            CultureInfo ci = null;
            try
            {
                ci = new CultureInfo(netLanguage);
            }
            catch (CultureNotFoundException cex)
            {
                try
                {
                    var fallback = ToDotnetFallbackLanguage(new PlatformCulture_service(netLanguage));
                    ci = new System.Globalization.CultureInfo(fallback);
                    System.Diagnostics.Debug.Write(cex.Message);
                }
                catch (CultureNotFoundException cex2)
                {
                    ci = new System.Globalization.CultureInfo("it");
                    System.Diagnostics.Debug.Write(cex2.Message);
                }
            }
            return ci;
        }

        public void SetLocaleCulture(CultureInfo cultureInfo)
        {
            Thread.CurrentThread.CurrentCulture = cultureInfo;
            Thread.CurrentThread.CurrentUICulture = cultureInfo;
        }

        string DroidToDotNetLanguage(string droidLang)
        {
            var netLanguage = droidLang;
            switch (droidLang)
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
                    // add more application-specific cases here (if required)
                    // ONLY use cultures that have been tested and known to work
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