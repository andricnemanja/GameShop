using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace GameShop.Validations
{
    internal class AdditionalDiscountValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string input = value as string;
            double number;

            if(!double.TryParse(input, out number))
                return new ValidationResult(false, "Popust mora biti broj");

            if (number < 0)
                return new ValidationResult(false, "Popust mora biti veci od 0");

            return new ValidationResult(true, null);
        }
    }
}
