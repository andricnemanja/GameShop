using System.Globalization;
using System.Windows.Controls;

namespace GameShop.Validations
{
    internal class PriceValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string input = value as string;
            double number;

            if (!double.TryParse(input, out number))
                return new ValidationResult(false, "Cena mora biti broj");

            if (number < 0)
                return new ValidationResult(false, "Cena mora biti veca od 0");

            return new ValidationResult(true, null);
        }
    }
}
