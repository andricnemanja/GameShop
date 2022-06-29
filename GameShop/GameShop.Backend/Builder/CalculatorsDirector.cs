using GameShop.Backend.Calculators;

namespace GameShop.Backend.Builder
{
    public class CalculatorsDirector
    {
        public CalculatorsBuilder CalculatorsBuilder { get; set; }

        public CalculatorsDirector(CalculatorsBuilder calculatorsBuilder)
        {
            CalculatorsBuilder = calculatorsBuilder;
        }

        public void BuildCalculators()
        {
            CalculatorsBuilder.BuildTaxCalculator();
            CalculatorsBuilder.BuildDiscountCalculator();
            CalculatorsBuilder.BuildAdditionalDiscountCalculator();
            CalculatorsBuilder.BuildAdditionalExpensesCalculator();
        }

        public List<ICalculator> GetCalculators()
        {
            return CalculatorsBuilder.Calculators;
        }


    }
}
