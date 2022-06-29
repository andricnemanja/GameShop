using GameShop.Backend.Model;
using GameShop.Backend.Settings;

namespace GameShop.Backend.Calculators
{
    public class DiscountLimitChecker
    {
        public static double CheckDiscountLimit(ProductPrice productPrice, double discount)
        {
            double discountLimitPercentage = GlobalSettings.Instance.DiscountLimit.DiscountLimitPercentage * productPrice.Product.Price / 100;
            double discountFixedAmount = GlobalSettings.Instance.DiscountLimit.DiscountLimitFixedAmount;

            if (discountLimitPercentage != 0 && discount + productPrice.PriceDetails.DiscountAmount > discountLimitPercentage)
                discount = discountLimitPercentage - productPrice.PriceDetails.DiscountAmount;
            else if (discountFixedAmount != 0 && discount + productPrice.PriceDetails.DiscountAmount > discountFixedAmount)
                discount = discountFixedAmount - productPrice.PriceDetails.DiscountAmount;

            return discount;
        }
    }
}
