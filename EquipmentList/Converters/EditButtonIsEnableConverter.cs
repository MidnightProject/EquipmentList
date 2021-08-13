using System;
using System.Globalization;
using System.Windows.Data;

namespace EquipmentList.Converters
{
    public class EditButtonIsEnableConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if ((int)values[0] != -1)
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
