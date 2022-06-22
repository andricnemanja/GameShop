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
        private double _tax;

        public double Tax
        {
            get { return _tax; }
            set { _tax = value; }
        }


        private static TaxCalculator _instance = null;
        public static TaxCalculator Instance
        {
            get 
            {
                if( _instance == null)
                    _instance = new TaxCalculator();
                return _instance; 
            }
        }

        private TaxCalculator()
        {
            Tax = 20;
        }

        public double Calculate(ProductPrice productPrice)
        {
            return productPrice.Product.Price * Tax / 100;
        }
    }
}
