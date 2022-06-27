using GameShop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameShop.Calculators
{
    public class AdditionalExpenseCalculator : ICalculator
    {
        public string Name { get; set; }
        public double PricePercentage { get; set; }
        public double Amount { get; set; }

        public AdditionalExpenseCalculator(string name, double pricePercentage, double amount)
        {
            Name = name;
            PricePercentage = pricePercentage;
            Amount = amount;
        }

        public double Calculate(ProductPrice productPrice)
        {
            return productPrice.Product.Price * PricePercentage / 100 + Amount;
        }

        public override string ToString()
        {
            return Name + " " + ((PricePercentage != 0) ? (PricePercentage + "%") : (Amount + "RSD"));
        }
    }
}
