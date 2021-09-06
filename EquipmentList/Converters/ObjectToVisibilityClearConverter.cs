using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace EquipmentList.Converters
{
    class ObjectToVisibilityClearConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            foreach (object value in values)
            {
                if (value != null)
                {
                    if (value.GetType().Equals(typeof(string)))
                    {
                        if (String.IsNullOrWhiteSpace((string)value) || String.IsNullOrEmpty((string)value))
                        {

                        }
                        else
                        {
                            return Visibility.Visible;
                        }
                    }

                    if (value.GetType().Equals(typeof(bool)))
                    {
                        if ((bool)value)
                        {
                            return Visibility.Visible;
                        }
                    }
                }
            }

            return Visibility.Collapsed;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}