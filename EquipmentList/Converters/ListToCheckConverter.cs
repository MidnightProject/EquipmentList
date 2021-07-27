using EquipmentList.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace EquipmentList.Converters
{
    public class ListToCheckConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values == null || values[0] == DependencyProperty.UnsetValue || (int)values[1] == -1)
            {
                return false;
            }

            int row = (int)values[1];
            var list = (IList<DataEmployee>)values[0];

            Boolean value = false;
            switch (parameter.ToString())
            {
                case "ACTIVE":
                    value = list[row].Active;
                    break;
                case "ADD_USER":
                    value = list[row].AddUser;
                    break;
                case "DELETE_USER":
                    value = list[row].DeleteUser;
                    break;
                case "EDIT_USER":
                    value = list[row].EditUser;
                    break;
                case "PRINT_USER":
                    value = list[row].PrintUser;
                    break;
                case "ADD_OWN_EQUIPMENT":
                    value = list[row].AddOwnEquipment;
                    break;
                case "DELETE_OWN_EQUIPMENT":
                    value = list[row].DeleteOwnEquipment;
                    break;
                case "ADD_OTHER_EQUIPMENT":
                    value = list[row].AddOtherEquipment;
                    break;
                case "DELETE_OTHER_EQUIPMENT":
                    value = list[row].DeleteOtherEquipment;
                    break;
                case "EDIT_OTHER_EQUIPMENT":
                    value = list[row].EditOtherEquipment;
                    break;
                case "VIEW_OTHER_EQUIPMENT":
                    value = list[row].ViewOtherEquipment;
                    break;
                case "PRINT_OTHER_EQUIPMENT":
                    value = list[row].PrintOtherEquipment;
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
