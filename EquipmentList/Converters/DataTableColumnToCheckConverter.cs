using System;
using System.Data;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace EquipmentList.Converters
{
    public class DataTableColumnToCheckConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values == null || values[0] == DependencyProperty.UnsetValue)
            {
                return false;
            }

            int row = (int)values[1];
            var value = ((DataTable)values[0]).Rows[row][(string)parameter];

            if (String.IsNullOrEmpty(value.ToString()))
            {
                return false;
            }

            return (Boolean)value;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
