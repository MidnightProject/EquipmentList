using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

namespace EquipmentList.Converters
{
    public class AlarmToColorConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values[4] == null || values[4] == DependencyProperty.UnsetValue)
            {
                return false;
            }

            if (((SolidColorBrush)values[4]).Color == Colors.Transparent)
            {
                return false;
            }

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
