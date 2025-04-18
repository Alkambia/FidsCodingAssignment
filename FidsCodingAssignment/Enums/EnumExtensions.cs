using System.ComponentModel;
using System;

namespace FidsCodingAssignment.Enums
{
    public static class EnumExtensions
    {
        public static string ToDescription(this FlightDirection val)
        {
            DescriptionAttribute[] attributes = (DescriptionAttribute[])val
               .GetType()
               .GetField(val.ToString())
               .GetCustomAttributes(typeof(DescriptionAttribute), false);
            return attributes.Length > 0 ? attributes[0].Description : string.Empty;
        }
    }
}
