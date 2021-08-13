using System;
using System.Globalization;
using System.Windows.Data;

namespace EquipmentList.Converters
{
    public class DateToGroupingByMounthConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value.ToDateTime() == new DateTime())
            {
                return String.Empty;
            }

            return value.ToDateTime().ToString("MMMM");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
