using System;
using System.ComponentModel;
using System.Reflection;

namespace Horizon.Blog.Service.Helpers
{
    public static class EnumHelper
    {
        public static string GetDescription(this Enum enumValue)
        {
            FieldInfo field = enumValue.GetType().GetField(enumValue.ToString());
            if (field == null)
                return "-";

            DescriptionAttribute attribute = Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) as DescriptionAttribute;
            return attribute == null ? enumValue.ToString() : attribute.Description;
        }
    }
}
