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

        public void Calculate(ProductPrice productPrice)
        {
            double discount = -productPrice.Product.Price * Discount / 100;
            productPrice.FinalPrice += discount;
            productPrice.PriceDetails.DiscountAmount += discount;
        }
    }
}
