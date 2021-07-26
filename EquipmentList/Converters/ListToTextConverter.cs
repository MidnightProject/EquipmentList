using EquipmentList.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Data;

namespace EquipmentList.Converters
{
    public class ListToTextConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values == null)
            {
                return String.Empty;
            }

            int row = (int)values[1];
            var list = (IList<DataEmployee>)values[0];

            string value = String.Empty;
            switch (parameter.ToString())
            {
                case "ADDRESSS":
                    value = list[row].ADDRESS;
                    break;
            }

            return value.ToString();
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
