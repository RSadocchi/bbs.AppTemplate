using System.Collections.Generic;

namespace bbs.AppTemplate.Globals.Settings
{
    public interface IAppSettings
    {
        List<Property> GetSettings();

        void SaveSettingsState();
    }
}
