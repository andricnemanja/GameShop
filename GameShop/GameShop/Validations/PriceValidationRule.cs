using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace GameShop.Validations
{
    internal class PriceValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string input = value as string;
            double number;

            if(!double.TryParse(input, out number))
                return new ValidationResult(false, "Cena mora biti ceo broj");

            return new ValidationResult(true, null);
        }
    }
}
