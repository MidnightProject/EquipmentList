using System;
using System.Globalization;
using System.Windows.Controls;

namespace EquipmentList.Validations
{
    public class NameValidationRule : ValidationRule
    {
        public NameValidationRule()
        {

        }

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string name = (string)value;

            if (String.IsNullOrEmpty(name))
            {
                return new ValidationResult(false, $"Property cannot be empty");
            }
             
            if (name == "[...]")
            {
                return new ValidationResult(false, $"Property cannot be '[...]'");
            }

            if (Wrapper != null)
            {
                if (Wrapper.Names == null)
                {
                    return ValidationResult.ValidResult;
                }

                foreach (string s in Wrapper.Names)
                {
                    if (name.ToUpper() == s.ToUpper())
                    {
                        return new ValidationResult(false, $"The name must be unique");
                    }
                }
            }

            return ValidationResult.ValidResult;
        }

        public Wrapper Wrapper { get; set; }
    }
}
