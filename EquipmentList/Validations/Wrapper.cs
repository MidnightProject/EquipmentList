using System.Collections.ObjectModel;
using System.Windows;

namespace EquipmentList.Validations
{
    public class Wrapper : DependencyObject
    {
        public static readonly DependencyProperty NamesProperty =
             DependencyProperty.Register("Names", typeof(ObservableCollection<string>),
             typeof(Wrapper), new FrameworkPropertyMetadata(new ObservableCollection<string>()));

        public ObservableCollection<string> Names
        {
            get { return (ObservableCollection<string>)GetValue(NamesProperty); }
            set { SetValue(NamesProperty, value); }
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
