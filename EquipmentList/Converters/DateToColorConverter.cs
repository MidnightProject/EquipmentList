using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

namespace EquipmentList.Converters
{
    public class DateToColorConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values[1] == null || values[1] == DependencyProperty.UnsetValue)
            {
                return false;
            }

            if (((SolidColorBrush)values[1]).Color == Colors.Transparent)
            {
                return false;
            }

            if (values[0].ToDateTime() == new DateTime())
            {
                return false;
            }

            if (values[0].ToDateTime() < DateTime.Now)
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
