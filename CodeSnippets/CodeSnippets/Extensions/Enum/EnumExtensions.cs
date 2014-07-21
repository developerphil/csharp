using System.Linq;
using NUnit.Framework;

namespace System
{
    public static class EnumExtensions
    {
        public static string GetName(this Enum value)
        {
            return Enum.GetName(value.GetType(), value);
        }

        public static string GetDescription(this Enum value)
        {
            var fieldInfo = value.GetType().GetField(value.GetName());
            var descriptionAttribute = fieldInfo.GetCustomAttributes(typeof (DescriptionAttribute), false).FirstOrDefault() as DescriptionAttribute;

            return descriptionAttribute == null ? value.GetName() : descriptionAttribute.Description;
        }

        public enum Module
        {
            [ComponentModel.Description("Intro")]
            Intro,
            Advanced
        }
    }
}
