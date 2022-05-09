using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameShop
{
    public class Product
    {
        public string Name { get; set; }
        public int UPC { get; set; }
        public double Price { get; set; }
        public double FinalPrice { get; set; }
        public double DiscountAmount { get; set; }
        public double TaxAmount { get; set; }
        public double AdditionalDiscountAmount { get; set; }

        public Product()
        {
            DiscountAmount = 0;
            AdditionalDiscountAmount = 0;
            TaxAmount = 0;
        }

        public void Update(double newTax, double newDiscount)
        {
            FinalPrice = Math.Round(Price + Price * newTax / 100 - Price * newDiscount / 100 - AdditionalDiscountAmount, 2);
            if(FinalPrice < 0) 
                FinalPrice = 0;

            DiscountAmount = Math.Round(Price * newDiscount / 100, 2);
            TaxAmount = Math.Round(Price * newTax / 100, 2);

            if(DiscountAmount > Price + TaxAmount) 
                DiscountAmount = Price + TaxAmount;
        }

        public void UpdateAdditionalDiscount(double additionalDiscount)
        {
            AdditionalDiscountAmount = Math.Round(Price * additionalDiscount / 100, 2);
            FinalPrice = Price + TaxAmount - DiscountAmount - AdditionalDiscountAmount;
        }
    }
}
