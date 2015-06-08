using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ReferenceData.Validation
{   
    /// <summary>
    /// Validation rule for TextBox, when it should be not empty
    /// </summary>
    public class TextBoxValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (string.IsNullOrEmpty(value.ToString()))
            {
                return new ValidationResult(false, "Please input value.");
            }
            else
            {
                return ValidationResult.ValidResult;
            }
        }
    }

}
