using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace EquipmentList.Converters
{
    public class WarningToColorConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            return true;
            return false;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
