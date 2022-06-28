using GameShop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameShop.Calculators
{
    public class DiscountCalculator : ICalculator
    {
        public double Discount { get; set; }

        public DiscountCalculator(double discount)
        {
            Discount = discount;
        }

        public double Calculate(ProductPrice productPrice)
        {
            return -productPrice.Product.Price * Discount / 100;
        }
    }
}
