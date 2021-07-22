using System;
using System.Data;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace EquipmentList.Converters
{
    public class DataTableColumnToTextConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values == null || values[0] == DependencyProperty.UnsetValue)
            {
                return String.Empty;
            }

            int row = (int)values[1];
            return ((DataTable)values[0]).Rows[row]["COUNTRY"].ToString();
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
