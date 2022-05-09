using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace GameShop.Validations
{
    internal class UPCValidationRule : ValidationRule
    {
        public ProductDatabase ProductDatabase { get; set; }
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string upcString = value as string;
            int UPC;

            if (string.IsNullOrEmpty(upcString))
                return new ValidationResult(false, null);

            if (!int.TryParse(upcString, out UPC))
                return new ValidationResult(false, "UPC mora biti ceo broj");

            if (!ProductDatabase.IsUPCUnique(UPC))
                return new ValidationResult(false, "UPC mora biti jedinstven");

            if (UPC < 0)
                return new ValidationResult(false, "UPC mora biti veci od 0");

            return new ValidationResult(true, null);
        }
    }
}
