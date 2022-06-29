using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameShop.Builder
{
    public interface ICalculatorsBuilder
    {
        public void BuildTaxCalculator();
        public void BuildDiscountCalculator();
        public void BuildAdditionalDiscountCalculator();
        public void BuildAdditionalExpensesCalculator();

    }
}
