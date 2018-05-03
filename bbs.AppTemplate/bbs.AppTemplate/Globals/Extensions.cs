using bbs.AppTemplate.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace bbs.AppTemplate.Globals
{
    public static class Extensions
    {
        public static FontSize GetOrientationFontSize<Tsource>(this Tsource source) where Tsource : struct, IConvertible
        {
            if (!typeof(Tsource).IsEnum) return null;
            Type attr = null;
            var value = (FontSize)Attribute.GetCustomAttribute(attr, typeof(FontSize));
            if (value == null) return null;
            return value;
        }

        public static string GetStringValue<T>(this T source) where T : struct, IConvertible
        {
            if (!typeof(T).IsEnum) return null;
            Type attr = null;
            StringValue value = (StringValue)Attribute.GetCustomAttribute(attr, typeof(StringValue));
            if (value == null) return null;
            return value.Value;
        }

        public static TValue GetComplexValue<T, TValue>(this T sourcee)
            where T : struct, IConvertible
            where TValue : Type
        {
            if (!typeof(T).IsEnum) return null;
            Type attr = null;
            ComplexValue value = (ComplexValue)Attribute.GetCustomAttribute(attr, typeof(ComplexValue));
            if (value == null) return null;
            if (value.ValueType != null && value.ValueType != typeof(TValue))
                throw new InvalidCastException($"Value is type of '{value.ValueType.GetType()}', cannot be casted in {typeof(TValue)}");
            return (TValue)value.Value;
        }
    }
}
