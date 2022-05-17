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
        public double Tax { get; set; }
        public double TaxAmount { get; set; }
        public double AdditionalDiscountAmount { get; set; }
        public double TotalDiscount { get; set; }
        public bool AdditionalDiscountBeforeTax { get; 
            set;
        }
        public bool DiscountBeforeTax { get; 
            set; }

        public Product()
        {
            AdditionalDiscountBeforeTax = false;
            DiscountBeforeTax = false;
            DiscountAmount = 0;
            AdditionalDiscountAmount = 0;
            TaxAmount = 0;
            Tax = 0;
        }

        public void Update(double newTax, double newDiscount)
        {
            Tax = newTax;
            DiscountAmount = Math.Round(Price * newDiscount / 100, 2);
            TaxAmount = CalculateTaxAmount();
            FinalPrice = Price + TaxAmount - DiscountAmount - AdditionalDiscountAmount;

            if (FinalPrice < 0) 
                FinalPrice = 0;

            TotalDiscount = DiscountAmount + AdditionalDiscountAmount;

            if(DiscountAmount > Price + TaxAmount) 
                DiscountAmount = Price + TaxAmount;
        }

        public void UpdateAdditionalDiscount(double additionalDiscount)
        {
            AdditionalDiscountAmount = Math.Round(Price * additionalDiscount / 100, 2);
            TotalDiscount = DiscountAmount + AdditionalDiscountAmount;
            TaxAmount = CalculateTaxAmount();
            FinalPrice = Price + TaxAmount - DiscountAmount - AdditionalDiscountAmount;
        }

        private double CalculateTaxAmount()
        {
            if (DiscountBeforeTax && AdditionalDiscountBeforeTax)
            {
                return Math.Round((Price - AdditionalDiscountAmount - DiscountAmount) * Tax / 100, 2);
            }

            if (DiscountBeforeTax == false && AdditionalDiscountBeforeTax)
            {
                return Math.Round((Price - AdditionalDiscountAmount) * Tax / 100, 2);
            }

            if (DiscountBeforeTax && AdditionalDiscountBeforeTax == false)
            {
                return Math.Round((Price - DiscountAmount) * Tax / 100, 2);
            }
            
            return Math.Round(Price * Tax / 100, 2);
            
        }
    }
}
