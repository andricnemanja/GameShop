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

        private static TaxCalculator _instance = null;
        public static TaxCalculator Instance
        {
            get 
            {
                if( _instance == null)
                {
                    return new TaxCalculator();
                }
                return _instance; 
            }
        }

        public TaxCalculator()
        {
            Tax = 20;
        }

        public double Calculate(ProductPrice productPrice)
        {
            return productPrice.Product.Price * Tax;
        }
    }
}
