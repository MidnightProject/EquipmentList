using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace EquipmentList.Converters
{
    class NullEmployeeToWarningVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string val = (string)value;

            if (String.IsNullOrEmpty(val.Substring(0, val.IndexOf("#"))))
            {
                return Visibility.Visible;
            }
            else
            {
                return Visibility.Collapsed;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
