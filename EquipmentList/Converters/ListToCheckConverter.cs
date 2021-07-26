using EquipmentList.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Data;

namespace EquipmentList.Converters
{
    public class ListToCheckConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values == null)
            {
                return false;
            }

            int row = (int)values[1];
            var list = (IList<DataEmployee>)values[0];

            Boolean value = false;
            switch (parameter.ToString())
            {
                case "ACTIVE":
                    value = list[row].ACTIVE;
                    break;
            }

            return value;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
