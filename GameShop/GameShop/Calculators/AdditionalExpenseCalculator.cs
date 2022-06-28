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

        public void Calculate(ProductPrice productPrice)
        {
            double expense = productPrice.Product.Price * PricePercentage / 100 + Amount;
            productPrice.FinalPrice += expense;
            productPrice.PriceDetails.ExpensesAmount += expense;
        }
    }
}
