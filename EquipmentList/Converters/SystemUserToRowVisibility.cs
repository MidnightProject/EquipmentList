using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace EquipmentList.Converters
{
    public class SystemUserToRowVisibility : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values == null || values[1] == DependencyProperty.UnsetValue)
            {
                return Visibility.Collapsed;
            }

            string user = values[0].ToString();
            if (user == "Admin" || user == "Guest")
            {
                if ((Boolean)values[1])
                {
                    return Visibility.Collapsed;
                }
            }

            return Visibility.Visible;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
