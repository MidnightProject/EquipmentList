using System;
using System.Globalization;
using System.Windows.Data;

namespace EquipmentList.Converters
{
    public class EmailToMailtoConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (String.IsNullOrEmpty((string)value))
            {
                return String.Empty;
            }
            else
            {
                return "mailto:" + (string)value;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
