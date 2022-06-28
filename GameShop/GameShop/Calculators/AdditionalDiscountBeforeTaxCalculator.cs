using GameShop.Model;
using GameShop.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameShop.Calculators
{
    public class AdditionalDiscountBeforeTaxCalculator : ICalculator
    {
        public double Percentage { get; set; }

        public AdditionalDiscountBeforeTaxCalculator(double percentage)
        {
            Percentage = percentage;
        }
        public double Calculate(ProductPrice productPrice)
        {
            // Calculators[0] is TaxCalculator, Calculator[1] is DiscountCalculator
            if (GlobalSettings.Instance.DiscountType == DiscountType.ADDITIVE)
                return -(productPrice.Product.Price + productPrice.Calculators[0].Calculate(productPrice)) * Percentage / 100;

            double tax = productPrice.Calculators[0].Calculate(productPrice);
            double regularDiscount = productPrice.Calculators[1].Calculate(productPrice);

            return -(productPrice.Product.Price + tax + regularDiscount) * Percentage / 100;
        }
    }
}
