using GameShop.Backend.Model;

namespace GameShop.Backend.Calculators
{
    public class TaxCalculator : ICalculator
    {
        public double Tax { get; set; }

        public TaxCalculator(double tax)
        {
            Tax = tax;
        }

        public void Calculate(ProductPrice productPrice)
        {
            double tax = productPrice.Product.Price * Tax / 100;
            productPrice.FinalPrice += tax;
            productPrice.PriceDetails.TaxAmount += tax;
        }
    }
}
