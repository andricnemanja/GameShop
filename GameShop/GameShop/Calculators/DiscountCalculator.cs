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

        private static DiscountCalculator _instance = null;

        public static DiscountCalculator Instance
        {
            get
            {
                if (_instance == null)
                    return new DiscountCalculator();
                return _instance;
            }
        }

        public DiscountCalculator()
        {
            Discount = 0;
        }

        public double Calculate(ProductPrice productPrice)
        {
            return productPrice.Product.Price * Discount / 100;
        }
    }
}
