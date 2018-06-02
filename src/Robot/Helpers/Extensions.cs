using System;

namespace Robot.Helpers
{
    public static class Extensions
    {
        public static T? ToEnum<T>(this string value, T? defaultValue = null) where T : struct
        {
            if (string.IsNullOrEmpty(value))
            {
                return defaultValue;
            }

            T result;
            return Enum.TryParse<T>(value, true, out result) ? result : defaultValue;
        }
    }
}
