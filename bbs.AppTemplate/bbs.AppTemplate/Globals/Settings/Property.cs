using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace bbs.AppTemplate.Globals.Settings
{
    public enum PropertyKeys
    {
        DefaultLang,
        DbSqliteName,

        Auth_IsConfigured,
        Auth_IsRequired,
        Auth_UseBiometric,
        Auth_LastSucces,
        Auth_LastFail
    }

    public struct Property
    {
        public PropertyKeys Key { get; private set; }

        object _value;
        public object Value
        {
            get { return _value; }
            set
            {
                if (value == _value)
                    return;
                _value = value;
                Key.SetPropertyValue(_value);
            }
        }

        public Property(PropertyKeys key, object val)
        {
            Key = key;
            _value = val;
        }
    }
}
