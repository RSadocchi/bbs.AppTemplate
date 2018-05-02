using System;

namespace bbs.AppTemplate.Services
{
    public class PlatformCulture_service
    {
        public PlatformCulture_service(string platformCultureString)
        {
            if (string.IsNullOrWhiteSpace(platformCultureString))
                throw new ArgumentException("Expected culture identifier.", "platformCultureString");

            PlatformString = platformCultureString.Replace("_", "-");

            var dashIndex = PlatformString.IndexOf("-", StringComparison.Ordinal);
            if (dashIndex > 0)
            {
                var parts = PlatformString.Split('-');
                LanguageCode = parts[0];
                LocaleCode = parts[1];
            }
            else
            {
                LanguageCode = PlatformString;
                LocaleCode = "";
            }
        }

        public string PlatformString { get; private set; }
        public string LanguageCode { get; private set; }
        public string LocaleCode { get; private set; }

        public override string ToString()
        {
            return PlatformString;
        }
    }
}
