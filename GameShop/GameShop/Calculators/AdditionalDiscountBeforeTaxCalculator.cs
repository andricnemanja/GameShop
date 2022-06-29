using GameShop.Model;
using GameShop.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameShop.Calculators
{
    public class AdditionalDiscountBeforeTaxCalculator : ICalculator
    {
        public double Percentage { get; set; }

        public AdditionalDiscountBeforeTaxCalculator(double percentage)
        {
            Percentage = percentage;
        }
        public void Calculate(ProductPrice productPrice)
        {
            double taxAmount = productPrice.Product.Price * GlobalSettings.Instance.Tax / 100;
            double regularDiscount = productPrice.Product.Price * GlobalSettings.Instance.Discount / 100;
            double additionalDiscount;

            if (GlobalSettings.Instance.DiscountType == DiscountType.ADDITIVE)
                additionalDiscount = (productPrice.Product.Price + taxAmount) * Percentage / 100;
            else
                additionalDiscount = (productPrice.Product.Price + taxAmount - regularDiscount) * Percentage / 100;

            additionalDiscount = DiscountLimitChecker.CheckDiscountLimit(productPrice, additionalDiscount);

            productPrice.FinalPrice -= additionalDiscount;
            productPrice.PriceDetails.DiscountAmount += additionalDiscount;
        }
    }
}
