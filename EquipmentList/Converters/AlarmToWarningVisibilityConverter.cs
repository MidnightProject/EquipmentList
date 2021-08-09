using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace EquipmentList.Converters
{
    public class AlarmToWarningVisibilityConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values[0].ToDateTime().AddDays((int)values[1]) < DateTime.Now)
            {
                return true;
            }

            if (values[2].ToDateTime().AddDays((int)values[3]) < DateTime.Now)
            {
                return true;
            }

            return false;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
