namespace GameShop.Backend.Settings
{
    public class DiscountLimit
    {
        public double DiscountLimitPercentage { get; set; }

        public double DiscountLimitFixedAmount { get; set; }

        public DiscountLimit(double discountLimitPercentage, double discountLimitFixedAmount)
        {
            DiscountLimitPercentage = discountLimitPercentage;
            DiscountLimitFixedAmount = discountLimitFixedAmount;
        }
    }
}
