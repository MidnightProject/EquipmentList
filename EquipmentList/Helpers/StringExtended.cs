using System;

namespace EquipmentList.Helpers
{
    public static class StringExtended
    {
        public static string TrimEndString(this string s)
        {
            if (String.IsNullOrEmpty(s))
            {
                return null;
            }

            return s.TrimEnd();
        }

        public static string TrimStartString(this string s)
        {
            if (String.IsNullOrEmpty(s))
            {
                return String.Empty;
            }

            return s.TrimStart();
        }

        public static string IsNullGetEmpty(this string s)
        {
            if (String.IsNullOrEmpty(s))
            {
                return String.Empty;
            }

            return s;
        }
    }
}
