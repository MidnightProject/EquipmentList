using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace EquipmentList.Validations
{
    public class BuildingNameValidationRule : ValidationRule
    {
        public BuildingNameValidationRule()
        {

        }

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string name = (string)value;

            if (String.IsNullOrEmpty(name))
            {
                return new ValidationResult(false, $"Name cannot be empty");
            }

            if (Wrapper.BuildingsNames.Contains(name, StringComparer.OrdinalIgnoreCase))
            {
                return new ValidationResult(false, $"The name must be unique");
            }

            return ValidationResult.ValidResult;
        }

        public Wrapper Wrapper { get; set; }
    }

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
    }
}
