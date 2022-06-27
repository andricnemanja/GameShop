using GameShop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameShop.Calculators
{
    public class TaxCalculator : ICalculator
    {
        public double Tax { get; set; }

        public TaxCalculator(double tax)
        {
            Tax = tax;
        }

        public double Calculate(ProductPrice productPrice)
        {
            return productPrice.Product.Price * Tax / 100;
        }
    }
}
