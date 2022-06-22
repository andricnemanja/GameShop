using GameShop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameShop.Calculators
{
    public class AdditionalDiscountCalculator : ICalculator
    {
        public double Percentage { get; set; }

        public AdditionalDiscountCalculator(double percentage)
        {
            Percentage = percentage;
        }

        public double Calculate(ProductPrice productPrice)
        {
            return -productPrice.Product.Price * Percentage / 100;
        }
    }
}
