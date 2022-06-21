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
        public int Percentage { get; set; }
        public double Calculate(ProductPrice productPrice)
        {
            return -productPrice.Product.Price * Percentage;
        }
    }
}
