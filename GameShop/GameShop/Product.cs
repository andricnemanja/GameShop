using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        private double _discount;
        public double Discount
        {
            get { return _discount; }
            set 
            {
                if (_discount != value)
                {
                    _discount = value;
                    RaisePropertyChanged("Discount");
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


        public ObservableCollection<AdditionalExpense> AdditionalExpenses { get; set; }

        private double _additionalExpensesAmount = 0;

        public double AdditionalExpensesAmount
        {
            get { return _additionalExpensesAmount; }
            set 
            { 
                if(_additionalExpensesAmount != value)
                {
                    _additionalExpensesAmount = value;
                    RaisePropertyChanged("AdditionalExpensesAmount");
                }
            }
        }

        public Product()
        {
            AdditionalDiscountBeforeTax = false;
            DiscountAmount = 0;
            AdditionalDiscountAmount = 0;
            TaxAmount = 0;
            Tax = 0;
            AdditionalExpenses = new ObservableCollection<AdditionalExpense>();
        }

        public void Update(double newTax, double newDiscount)
        {
            Tax = newTax;
            Discount = newDiscount;
            DiscountAmount = CalculateDiscountAmount();
            TaxAmount = CalculateTaxAmount();
            FinalPrice = CalculateFinalPrice();

            TotalDiscount = DiscountAmount + AdditionalDiscountAmount;

            if (FinalPrice < 0) 
                FinalPrice = 0;

            if(DiscountAmount > Price + TaxAmount) 
                DiscountAmount = Price + TaxAmount;
        }

        public void UpdateAdditionalDiscount(double additionalDiscount)
        {
            AdditionalDiscountAmount = Math.Round(Price * additionalDiscount / 100, 2);
            Update(Tax, Discount);
        }

        private double CalculateTaxAmount()
        {
            if (AdditionalDiscountBeforeTax)
                return Math.Round((Price - AdditionalDiscountAmount) * Tax / 100, 2);
            return Math.Round(Price * Tax / 100, 2);
            
        }

        private double CalculateFinalPrice()
        {
            if (AdditionalDiscountBeforeTax)
                Math.Round(Price + TaxAmount - DiscountAmount - AdditionalDiscountAmount, 2);
            return Math.Round(Price + TaxAmount - DiscountAmount - AdditionalDiscountAmount, 2);
        }

        private double CalculateDiscountAmount()
        {
            if(AdditionalDiscountBeforeTax)
                return Math.Round((Price-AdditionalDiscountAmount) * Discount / 100, 2);
            return Math.Round(Price * Discount / 100, 2);
        }


        public void AddExpense(AdditionalExpense newAdditionalExpense)
        {
            AdditionalExpenses.Add(newAdditionalExpense);
            if(newAdditionalExpense.Amount != 0)
            {
                FinalPrice += newAdditionalExpense.Amount;
                AdditionalExpensesAmount += newAdditionalExpense.Amount;
                return;
            }
            double newAdditionalExpenseAmount = Math.Round(Price * newAdditionalExpense.PricePercentage / 100, 2);
            FinalPrice += newAdditionalExpenseAmount;
            AdditionalExpensesAmount += newAdditionalExpenseAmount;
        }

        public void RemoveExpense(AdditionalExpense additionalExpense)
        {
            AdditionalExpenses.Remove(additionalExpense);

            if(additionalExpense.Amount > 0)
            {
                FinalPrice -= additionalExpense.Amount;
                AdditionalExpensesAmount -= additionalExpense.Amount;
                return;
            }

            FinalPrice = Math.Round(FinalPrice - additionalExpense.PricePercentage / 100 * Price);
            AdditionalExpensesAmount = Math.Round(AdditionalExpensesAmount - additionalExpense.PricePercentage / 100 * Price);

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
