using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameShop.Settings
{
    public class AdditionalExpense
    {
        public string Name { get; set; }

        private double _pricePercentage;
        public double PricePercentage
        {
            get { return _pricePercentage; }
            set 
            { 
                _pricePercentage = value;
                _fixedAmount = 0;
            }
        }

        private double _fixedAmount;
        public double FixedAmount
        {
            get { return _fixedAmount; }
            set 
            { 
                _fixedAmount = value;
                _pricePercentage = 0;
            }
        }
    }
}
