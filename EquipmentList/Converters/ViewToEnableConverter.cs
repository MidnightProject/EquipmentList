using System;
using System.Globalization;
using System.Windows.Data;
using static EquipmentList.Model.Views;

namespace EquipmentList.Converters
{
    class ViewToEnableConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            DefinedViews view = (DefinedViews)values[0];

            if (view == DefinedViews.EquipmentView && parameter.ToString() == DefinedViews.EquipmentView.ToString())
            {
                return false;
            }

            if (view == DefinedViews.EmployeeView && parameter.ToString() == DefinedViews.EmployeeView.ToString())
            {
                return false;
            }

            if (view == DefinedViews.BuildingView && parameter.ToString() == DefinedViews.BuildingView.ToString())
            {
                return false;
            }

            return true;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
