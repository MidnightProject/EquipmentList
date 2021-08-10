using System;
using System.Globalization;
using System.Windows.Data;

namespace EquipmentList.Converters
{
    class DateToShortDateStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value.ToDateTime() == new DateTime())
            {
                return "N/A";
            }

            return value.ToDateTime().ToShortDateString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
