﻿using GameShop.Model;
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

        public double Calculate(ProductPrice productPrice)
        {
            // Calculators[0] is TaxCalculator, Calculator[1] is DiscountCalculator
            if (GlobalSettings.Instance.DiscountType == DiscountType.ADDITIVE)
                return -productPrice.Product.Price * Percentage / 100;

            double priceWithRegularDiscount = productPrice.Product.Price + productPrice.Calculators[1].Calculate(productPrice);
            return -priceWithRegularDiscount * Percentage / 100;
        }
    }
}
