using GameShop.Model;
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
        public TaxCalculator TaxCalculator { get; set; }

        public AdditionalDiscountBeforeTaxCalculator(TaxCalculator taxCalculator, double percentage)
        {
            TaxCalculator = taxCalculator;
            Percentage = percentage;
        }
        public double Calculate(ProductPrice productPrice)
        {
            return  - (productPrice.Product.Price + TaxCalculator.Calculate(productPrice)) * Percentage / 100;
        }
    }
}
