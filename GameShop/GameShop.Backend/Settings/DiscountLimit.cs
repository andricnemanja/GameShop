using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameShop.Settings
{
    public class DiscountLimit
    {
        public bool IsPercentage { get; set; }

        private double _discountLimitPercentage;
        public double DiscountLimitPercentage
        {
            get { return _discountLimitPercentage; }
            set 
            { 
                _discountLimitPercentage = value; 
                if(value != 0)
                    IsPercentage = true;
                else
                    IsPercentage = false;
            }
        }

        public double DiscountLimitFixedAmount { get; set; }

        public DiscountLimit(double discountLimitPercentage, double discountLimitFixedAmount)
        {
            DiscountLimitPercentage = discountLimitPercentage;
            DiscountLimitFixedAmount = discountLimitFixedAmount;
        }
    }
}
