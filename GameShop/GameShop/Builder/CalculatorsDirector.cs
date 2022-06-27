using GameShop.Calculators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameShop.Builder
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
