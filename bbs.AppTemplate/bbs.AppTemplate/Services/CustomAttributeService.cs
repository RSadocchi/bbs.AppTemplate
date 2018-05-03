using System;
using Xamarin.Forms;

namespace bbs.AppTemplate.Services
{
    [AttributeUsage(AttributeTargets.Enum | AttributeTargets.Field, AllowMultiple = false, Inherited = false)]
    public class FontSize : Attribute
    {
        public double ExtraSmall { get; private set; }
        public double Small { get; private set; }
        public double Normal { get; private set; }
        public double Large { get; private set; }
        public double ExtraLarge { get; private set; }

        public Size? MinSize { get; private set; }
        public Size? MaxSize { get; private set; }

        public FontSize(double xsmall, double small, double normal, double large, double xlarge, 
            Size? minSize = null, Size? maxSize = null)
        {
            ExtraSmall = xsmall;
            Small = small;
            Normal = normal;
            Large = large;
            ExtraLarge = large;
            MinSize = minSize;
            MaxSize = maxSize;
        }
    }

    [AttributeUsage(AttributeTargets.Enum | AttributeTargets.Field, AllowMultiple = false, Inherited = false)]
    public class StringValue : Attribute
    {
        public string Value { get; private set; }
        public StringValue(string value)
        {
            Value = value;
        }
    }

    [AttributeUsage(AttributeTargets.Enum | AttributeTargets.Field, AllowMultiple = false, Inherited = false)]
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
