using System;

namespace EquipmentList.Helpers
{
    public static class StringExtended
    {
        public static string TrimString(this string s)
        {
            if (String.IsNullOrEmpty(s))
            {
                return s;
            }

            return s.TrimEnd();
        }
    }
}
