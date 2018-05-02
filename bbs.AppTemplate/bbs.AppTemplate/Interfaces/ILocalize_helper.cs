
namespace bbs.AppTemplate.Interfaces
{
    public interface ILocalize_helper
    {
        System.Globalization.CultureInfo GetCurrentCulture();
        void SetLocaleCulture(System.Globalization.CultureInfo cultureInfo);
    }
}
