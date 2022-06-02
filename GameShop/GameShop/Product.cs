using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameShop
{
    public class Product : INotifyPropertyChanged
    {
        private string _name;
        public string Name
        {
            get { return _name; }
            set 
            {
                if(_name != value)
                {
                    _name = value; 
                    RaisePropertyChanged("Name");
                }
            }
        }

        private int _upc;
        public int UPC
        {
            get { return _upc; }
            set
            {
                if (_upc != value)
                {
                    _upc = value;
                    RaisePropertyChanged("UPC");
                }
            }
        }

        private double _price;
        public double Price
        {
            get { return _price; }
            set
            {
                if (_price != value)
                {
                    _price = value;
                    RaisePropertyChanged("Price");
                }
            }
        }

        private double _finalPrice;
        public double FinalPrice
        {
            get { return _finalPrice; }
            set
            {
                if (_finalPrice != value)
                {
                    _finalPrice = value;
                    RaisePropertyChanged("FinalPrice");
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

        private double _tax;
        public double Tax
        {
            get { return _tax; }
            set
            {
                if (_tax != value)
                {
                    _tax = value;
                    RaisePropertyChanged("DiscountAmount");
                }
            }
        }

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

        private double _additionalDiscountAmount;
        public double AdditionalDiscountAmount
        {
            get { return _additionalDiscountAmount; }
            set
            {
                if (_additionalDiscountAmount != value)
                {
                    _additionalDiscountAmount = value;
                    RaisePropertyChanged("AdditionalDiscountAmount");
                }
            }
        }

        private double _totalDiscount;
        public double TotalDiscount
        {
            get { return _totalDiscount; }
            set
            {
                if (_totalDiscount != value)
                {
                    _totalDiscount = value;
                    RaisePropertyChanged("TotalDiscount");
                }
            }
        }

        private bool _additionalDiscountBeforeTax;
        public bool AdditionalDiscountBeforeTax
        {
            get { return _additionalDiscountBeforeTax; }
            set
            {
                if (_additionalDiscountBeforeTax != value)
                {
                    _additionalDiscountBeforeTax = value;
                    RaisePropertyChanged("AdditionalDiscountBeforeTax");
                }
            }
        }

        private bool _discountBeforeTax;
        public bool DiscountBeforeTax
        {
            get { return _discountBeforeTax; }
            set
            {
                if (_discountBeforeTax != value)
                {
                    _discountBeforeTax = value;
                    RaisePropertyChanged("DiscountBeforeTax");
                }
            }
        }

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
            FinalPrice = Math.Round(Price + TaxAmount - DiscountAmount - AdditionalDiscountAmount, 2);

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
            FinalPrice = Math.Round(Price + TaxAmount - DiscountAmount - AdditionalDiscountAmount, 2);
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

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }

    }
}
