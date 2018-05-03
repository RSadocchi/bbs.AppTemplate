using System;
using System.Collections.Generic;
using System.Linq;

namespace bbs.AppTemplate.Globals.Settings
{
    public class AppSettings : IAppSettings
    {
        public List<Property> GetSettings()
        {
            var settings = new List<Property>();
            var entities = bbs.AppTemplate.App.Current.Properties;
            entities.ToList().ForEach(e => { settings.Add(new Property((PropertyKeys)Enum.Parse(typeof(PropertyKeys), e.Key), e.Value)); });
            return settings;
        }

        public void SaveSettingsState()
        {
            var entities = GetSettings();
            entities.ForEach(e => { e.Key.SetPropertyValue(e.Value); });
        }

    }
}
