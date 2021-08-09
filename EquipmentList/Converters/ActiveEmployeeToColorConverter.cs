using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace EquipmentList.Converters
{
    public class ActiveEmployeeToColorConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values[1] == null)
            {
                return true;
            }

            if (((SolidColorBrush)values[1]).Color == Colors.Transparent)
            {
                return true;
            }

            return (Boolean)values[0];
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
