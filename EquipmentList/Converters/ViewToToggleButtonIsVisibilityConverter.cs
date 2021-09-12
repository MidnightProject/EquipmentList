using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using static EquipmentList.View.Views;

namespace EquipmentList.Converters
{
    class ViewToToggleButtonIsVisibilityConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            DefinedViews view = (DefinedViews)values[0];

            if (view == DefinedViews.EquipmentView)
            {
                return Visibility.Visible;
            }

            return Visibility.Collapsed;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
