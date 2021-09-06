using System;
using System.Collections.Generic;
using System.Linq;

namespace EquipmentList.Helpers
{
    public static class IEnumerableExtended
    {
        public static bool IsSameValue<T, U>(this IEnumerable<T> list, Func<T, U> selector)
        {
            if (list.Select(selector).Distinct().Count() == 1)
            {
                return true;
            }

            return false;
        }
    }
}
