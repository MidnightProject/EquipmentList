using System;
using System.Globalization;
using System.Text;
using System.Windows.Data;
using static EquipmentList.Model.Views;

namespace EquipmentList.Converters
{
    public class ViewToTextConverter : IValueConverter
    {
        object IValueConverter.Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            StringBuilder sb = new StringBuilder();
            
            if ((string)parameter != "Group")
            {
                switch ((string)parameter)
                {
                    case "Add":
                        sb.Append("Add ");
                        break;
                    case "Remove":
                        sb.Append("Remove ");
                        break;
                    case "Edit":
                        sb.Append("Edit ");
                        break;
                }

                switch ((DefinedViews)value)
                {
                    case DefinedViews.BuildingView:
                        sb.Append("building");
                        break;
                    case DefinedViews.EmployeeView:
                        sb.Append("employee");
                        break;
                    case DefinedViews.EquipmentView:
                        sb.Append("equipment");
                        break;
                }
            }
            else
            {
                sb.Append("Group ");

                switch ((DefinedViews)value)
                {
                    case DefinedViews.BuildingView:
                        sb.Append("buildings");
                        break;
                    case DefinedViews.EmployeeView:
                        sb.Append("employees");
                        break;
                    case DefinedViews.EquipmentView:
                        sb.Append("equipments");
                        break;
                }
            }

            return sb.ToString();
        }

        object IValueConverter.ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
