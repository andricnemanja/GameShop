using System.Globalization;
using System.Windows.Controls;

namespace GameShop.Validations
{
    internal class TextBoxNotEmptyValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string input = value as string;

            if (string.IsNullOrWhiteSpace(input))
                return new ValidationResult(false, null);

            return new ValidationResult(true, null);
        }
    }
}
