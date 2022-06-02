using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameShop
{
    public class AdditionalExpense
    {
        public string Name { get; set; }
        private double _pricePercentage;

        public double PricePercentage
        {
            get { return _pricePercentage; }
            set { _pricePercentage = value; }
        }

        private double _amount;

        public double Amount
        {
            get { return _amount; }
            set { _amount = value; }
        }


        public override string ToString()
        {
            return Name + " " + ((PricePercentage != 0) ? (PricePercentage + "%") : (Amount + "RSD"));
        }

    }
}
