using System;
using System.Globalization;
using System.Windows.Data;

namespace EquipmentList.Converters
{
    public class PostedWorkerToColorConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values[2] == null)
            {
                return false;
            }

            string val = (string)values[0];

            if (String.IsNullOrEmpty(val.Substring(val.IndexOf("#") + 1)))
            {
                return false;
            }

            if (values[1].ToDateTime() == new DateTime())
            {
                return true;
            }

            if (values[1].ToDateTime() <  DateTime.Today)
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
