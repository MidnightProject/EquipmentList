using System;
using System.Globalization;
using System.Windows.Controls;
using System.Windows.Data;

namespace EquipmentList.Converters
{
    class SelectedIndexesToRowDetailsVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null && (int)value == 1)
            {
                return DataGridRowDetailsVisibilityMode.VisibleWhenSelected;
            }

            return DataGridRowDetailsVisibilityMode.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
