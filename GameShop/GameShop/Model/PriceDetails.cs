using GameShop.Calculators;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameShop.Model
{
    public class PriceDetails : INotifyPropertyChanged
    {
        private ProductPrice productPrice;

        private double _taxAmount;
        public double TaxAmount
        {
            get { return _taxAmount; }
            set
            { 
                if (_taxAmount != value)
                {
                    _taxAmount = value;
                    RaisePropertyChanged("TaxAmount");
                }
            }
        }

        private double _discountAmount;
        public double DiscountAmount
        {
            get { return _discountAmount; }
            set 
            { 
                if (_discountAmount != value)
                {
                    _discountAmount = value;
                    RaisePropertyChanged("DiscountAmount");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public PriceDetails(ProductPrice productPrice)
        {
            this.productPrice = productPrice;
            TaxAmount = 0;
            DiscountAmount = 0;
        }

        public void CalculatePriceDetails(ICalculator calculator)
        {
            if(calculator is TaxCalculator)
            {
                TaxAmount += calculator.Calculate(productPrice);
            }
            else if (calculator is DiscountCalculator || calculator is AdditionalDiscountCalculator
                || calculator is AdditionalDiscountBeforeTaxCalculator)
            {
                DiscountAmount += calculator.Calculate(productPrice);
            }
        }

        public void Reset()
        {
            TaxAmount = 0;
            DiscountAmount = 0;
        }

        private void RaisePropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }
    }
}
