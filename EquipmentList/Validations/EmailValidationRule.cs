using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Windows.Controls;

namespace EquipmentList.Validations
{
    public class EmailValidationRule : ValidationRule
    {
        public EmailValidationRule()
        {

        }

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (String.IsNullOrEmpty((string)value))
            {
                return ValidationResult.ValidResult;
            }

            try
            {
                new System.Net.Mail.MailAddress((string)value);
                return ValidationResult.ValidResult;
            }
            catch
            {
                return new ValidationResult(false, $"Invalid email address");
            }
        }

        public Wrapper Wrapper { get; set; }
    }
}
