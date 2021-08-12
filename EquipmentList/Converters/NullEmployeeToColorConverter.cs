using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

namespace EquipmentList.Converters
{
    class NullEmployeeToColorConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values[1] == null || values[1] == DependencyProperty.UnsetValue)
            {
                return false;
            }

            if (((SolidColorBrush)values[1]).Color == Colors.Transparent)
            {
                return false;
            }

            if (String.IsNullOrEmpty(values[0].ToString()))
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
