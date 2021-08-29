using System.Collections.ObjectModel;
using System.Windows;

namespace EquipmentList.Validations
{
    public class Wrapper : DependencyObject
    {
        public static readonly DependencyProperty BuildingsNamesProperty =
             DependencyProperty.Register("BuildingsNames", typeof(ObservableCollection<string>),
             typeof(Wrapper), new FrameworkPropertyMetadata(new ObservableCollection<string>()));

        public ObservableCollection<string> BuildingsNames
        {
            get { return (ObservableCollection<string>)GetValue(BuildingsNamesProperty); }
            set { SetValue(BuildingsNamesProperty, value); }
        }

        public static readonly DependencyProperty EmployeesNamesProperty =
             DependencyProperty.Register("EmployeesNames", typeof(ObservableCollection<string>),
             typeof(Wrapper), new FrameworkPropertyMetadata(new ObservableCollection<string>()));

        public ObservableCollection<string> EmployeesNames
        {
            get { return (ObservableCollection<string>)GetValue(EmployeesNamesProperty); }
            set { SetValue(EmployeesNamesProperty, value); }
        }

        public static readonly DependencyProperty EmployeeEmailProperty =
             DependencyProperty.Register("EmployeeEmail", typeof(ObservableCollection<string>),
             typeof(Wrapper), new FrameworkPropertyMetadata(new ObservableCollection<string>()));

        public ObservableCollection<string> EmployeeEmail
        {
            get { return (ObservableCollection<string>)GetValue(EmployeeEmailProperty); }
            set { SetValue(EmployeeEmailProperty, value); }
        }
    }
}
