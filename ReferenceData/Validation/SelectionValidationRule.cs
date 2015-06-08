using System.Windows.Controls;

namespace ReferenceData.Validation
{   
    /// <summary>
    /// Validation rule for Selection dropdown
    /// </summary>
    public class SelectionValidationRule : ValidationRule
    {
        public override ValidationResult Validate(dynamic value, System.Globalization.CultureInfo cultureInfo)
        {
            return  ((object)value == null) || value < 1 ? new ValidationResult(false, "Please select value") : ValidationResult.ValidResult;
        }
    }
}
