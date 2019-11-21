using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodaSystems.Core.Extensions
{
    public static class StringExtension
    {
        public static bool IsNullOrEmpty(this string str)
        {
            return string.IsNullOrEmpty(str);
        }

        public static bool IsInteger(this string value)
        {
            if (value.IsNullOrEmpty())
                return false;

            return int.TryParse(value, NumberStyles.Any, CultureInfo.InvariantCulture, out int _);
        }

        public static int ToInteger(this string value)
        {
            int result;
            bool success = int.TryParse(value, NumberStyles.Any, CultureInfo.InvariantCulture, out result);
            if (!success)
                throw new ArgumentException($"Was not able to convert '{value}' to integer");

            return result;
        }
    }
}
