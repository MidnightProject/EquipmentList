using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace EquipmentList.Converters
{
    class PostedWorkerToWarningVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string val = (string)value;

            if (String.IsNullOrEmpty(val.Substring(val.IndexOf("#") + 1)))
            {
                return Visibility.Collapsed;
            }
            else
            {
                return Visibility.Visible;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
