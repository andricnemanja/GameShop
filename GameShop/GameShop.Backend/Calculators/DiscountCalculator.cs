using GameShop.Backend.Model;

namespace GameShop.Backend.Calculators
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
            double discount = productPrice.Product.Price * Discount / 100;

            discount = DiscountLimitChecker.CheckDiscountLimit(productPrice, discount);

            productPrice.FinalPrice -= discount;
            productPrice.PriceDetails.DiscountAmount += discount;
        }
    }
}
