using GameShop.Backend.Model;

namespace GameShop.Backend.Calculators
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
