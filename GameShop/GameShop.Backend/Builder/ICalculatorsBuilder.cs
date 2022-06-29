namespace GameShop.Backend.Builder
{
    public interface ICalculatorsBuilder
    {
        public void BuildTaxCalculator();
        public void BuildDiscountCalculator();
        public void BuildAdditionalDiscountCalculator();
        public void BuildAdditionalExpensesCalculator();

    }
}
