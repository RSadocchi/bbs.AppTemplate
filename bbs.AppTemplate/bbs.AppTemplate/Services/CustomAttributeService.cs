using System;
using Xamarin.Forms;

namespace bbs.AppTemplate.Services
{
    [AttributeUsage(AttributeTargets.Enum | AttributeTargets.Field, AllowMultiple = true, Inherited = true)]
    public class FontSize : Attribute
    {
        #region Font Sizes
        public double ExtraSmall { get; private set; }
        public double Small { get; private set; }
        public double Normal { get; private set; }
        public double Large { get; private set; }
        public double ExtraLarge { get; private set; }
        #endregion

        #region Media Query
        public TargetIdiom TargetIdiom { get; set; }
        public string[] RuntimePlatforms { get; set; }
        public double MinWidth { get; set; }
        public double MaxWidth { get; set; }
        public double MinHeight { get; set; }
        public double MaxHeight { get; set; }
        #endregion

        #region Constructor
        public FontSize(double xsmall, double small, double normal, double large, double xlarge,
            TargetIdiom targetIdiom, string[] runtimePlatforms, double minWidth, double maxWidth, double minHeight, double maxHeight)
        {
            ExtraSmall = xsmall;
            Small = small;
            Normal = normal;
            Large = large;
            ExtraLarge = large;
            TargetIdiom = targetIdiom;
            RuntimePlatforms = runtimePlatforms;
            MinWidth = minWidth;
            MaxWidth = maxWidth;
            MinHeight = minHeight;
            MaxHeight = maxHeight;
        }
        #endregion
    }

    //[AttributeUsage(AttributeTargets.Enum | AttributeTargets.Field, AllowMultiple = true, Inherited = true)]
    //public class UIStyle : Attribute
    //{
    //    public string UniqueName { get; private set; }

    //    public Color Background { get; private set; }

    //    public Color TextPrimary { get; private set; }
    //    public Color TextSecondary { get; private set; }
    //    public Color TextComment { get; private set; }
    //    public Color TextOther { get; private set; }

    //}

    [AttributeUsage(AttributeTargets.Enum | AttributeTargets.Field, AllowMultiple = false, Inherited = false)]
    public class StringValue : Attribute
    {
        public string Value { get; private set; }
        public StringValue(string value)
        {
            Value = value;
        }
    }

    [AttributeUsage(AttributeTargets.Enum | AttributeTargets.Field, AllowMultiple = true, Inherited = true)]
    public class ComplexValue : Attribute
    {
        public object Value { get; private set; }
        public Type ValueType { get; private set; }
        public ComplexValue(object value, Type type)
        {
            Value = value;
            ValueType = type;
        }
    }
}
