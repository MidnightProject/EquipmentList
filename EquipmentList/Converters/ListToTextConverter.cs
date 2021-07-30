using EquipmentList.Model;
using System;
using System.Collections.Generic;
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

            int row = (int)values[1];

            string value = String.Empty;

            if (values[2].ToString() == "Employee")
            {
                var list = (IList<DataEmployee>)values[0];

                switch (parameter.ToString())
                {
                    case "ADDRESS":
                        value = list[row].Address;
                        break;
                    case "POSTCODE":
                        value = list[row].Postcode;
                        break;
                    case "CITY":
                        value = list[row].City;
                        break;
                    case "COUNTRY":
                        value = list[row].Country;
                        break;
                }

                return value.ToString();
            }

            if (values[2].ToString() == "Equipment")
            {
                var list = (IList<DataEquipment>)values[0];

                switch (parameter.ToString())
                {
                    case "EMPLOYEE_NAME":
                        value = list[row].EmployeeName;
                        break;
                }

                return value.ToString();
            }

            return value.ToString();
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
