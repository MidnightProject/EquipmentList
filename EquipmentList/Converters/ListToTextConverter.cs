using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace EquipmentList.Converters
{
    public class ListToTextConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values == null || values[0] == DependencyProperty.UnsetValue)
            {
                return String.Empty;
            }

            if (parameter == null)
            {
                parameter = String.Empty;
            }

            if (values[1].ToString() == "String")
            {
                return parameter.ToString() + values[0].ToString();
            }
            else if (values[1].ToString() == "Date")
            {
                if (values[0].ToDateTime() ==  new DateTime())
                {
                    return parameter.ToString() + "N/A";
                }

                return parameter.ToString() + values[0].ToDateTime().ToShortDateString();
            } if (values[1].ToString() == "Room")
            {
                if (String.IsNullOrEmpty(values[0].ToString()))
                {
                    return String.Empty;
                }

                return "Room: " + parameter.ToString() + values[0].ToString();
            }
            else if (values[1].ToString() == "Certificate")
            {
                if (String.IsNullOrEmpty(values[0].ToString()))
                {
                    return String.Empty;
                }

                return "Certificate number:  " + parameter.ToString() + values[0].ToString();
            }

            return String.Empty;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
