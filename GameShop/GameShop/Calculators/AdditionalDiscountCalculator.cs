using GameShop.Model;
using GameShop.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameShop.Calculators
{
    public class AdditionalDiscountCalculator : ICalculator
    {
        public double Percentage { get; set; }
        public AdditionalDiscountCalculator(double percentage)
        {
            Percentage = percentage;
        }

        public void Calculate(ProductPrice productPrice)
        {
            double discount;

            if (GlobalSettings.Instance.DiscountType == DiscountType.ADDITIVE)
            {
                discount = productPrice.Product.Price * Percentage / 100;
            }
            else
            {
                double regularDiscount = productPrice.Product.Price * GlobalSettings.Instance.Discount / 100;
                discount = (productPrice.Product.Price + regularDiscount) * Percentage / 100;
            }

            discount = DiscountLimitChecker.CheckDiscountLimit(productPrice, discount);
            
            productPrice.FinalPrice -= discount;
            productPrice.PriceDetails.DiscountAmount += discount;
                 
        }
    }
}
