using GameShop.Calculators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameShop.Model
{
    public class ProductPrice
    {
        public Product Product { get; set; }
        public double FinalPrice { get; set; }
        public List<ICalculator> Calculators { get; set; }

        public ProductPrice(Product product)
        {
            Product = product;
            Calculators = new List<ICalculator>();
        }

        public double CalculateFinalPrice()
        {
            FinalPrice = Product.Price;

            foreach (ICalculator calculator in Calculators)
            {
                FinalPrice += calculator.Calculate(this);
            }

            return FinalPrice;
        }

    }


}
