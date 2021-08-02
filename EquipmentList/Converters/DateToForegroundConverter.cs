using EquipmentList.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

namespace EquipmentList.Converters
{
    public class DateToForegroundConverter : IMultiValueConverter
    {
        object IMultiValueConverter.Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values == null || values[0] == DependencyProperty.UnsetValue)
            {
                return Brushes.Black;
            }

            int row = (int)values[1];

            if (row == -1)
            {
                return Brushes.Black;
            }

            var list = (IList<DataEquipment>)values[0];
            DateTime date = new DateTime();

            switch (parameter)
            {
                case "LEGALIZATION":
                    date = list[row].LegalizationDate;
                    break;
                case "REVIEW":
                    date = list[row].ReviewDate;
                    break;
            }

            if (date < DateTime.Today)
            {
                return Brushes.Red;
            }

            return Brushes.Black;
        }

        object[] IMultiValueConverter.ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
