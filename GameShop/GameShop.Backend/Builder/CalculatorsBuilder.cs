using GameShop.Backend.Calculators;
using GameShop.Backend.Settings;
using GameShop.Calculators;

namespace GameShop.Backend.Builder
{
    public class CalculatorsBuilder : ICalculatorsBuilder
    {
        public List<ICalculator> Calculators { get; set; }
        public ProductSettings ProductSettings { get; set; }

        public CalculatorsBuilder(ProductSettings productSettings)
        {
            Calculators = new List<ICalculator>();
            ProductSettings = productSettings;
        }

        public void BuildTaxCalculator()
        {
            Calculators.Add(new TaxCalculator(GlobalSettings.Instance.Tax));
        }

        public void BuildDiscountCalculator()
        {
            Calculators.Add(new DiscountCalculator(GlobalSettings.Instance.Discount));
        }

        public void BuildAdditionalDiscountCalculator()
        {
            if (ProductSettings.AdditionalDiscount == 0)
                return;

            if (ProductSettings.AdditionalDiscoubtBeforeTax)
                Calculators.Add(new AdditionalDiscountBeforeTaxCalculator(ProductSettings.AdditionalDiscount));
            else
                Calculators.Add(new AdditionalDiscountCalculator(ProductSettings.AdditionalDiscount));
        }

        public void BuildAdditionalExpensesCalculator()
        {
            foreach (AdditionalExpense additionalExpense in ProductSettings.AdditionalExpenses)
            {
                AdditionalExpenseCalculator calculator = new AdditionalExpenseCalculator(additionalExpense.Name,
                    additionalExpense.PricePercentage, additionalExpense.FixedAmount);
                Calculators.Add(calculator);
            }
        }
    }
}
