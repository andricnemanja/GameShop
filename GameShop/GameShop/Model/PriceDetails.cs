using GameShop.Calculators;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        private double _expensesAmount;
        public double ExpensesAmount
        {
            get { return _expensesAmount; }
            set 
            {
                if (_expensesAmount != value)
                {
                    _expensesAmount = value;
                    RaisePropertyChanged("ExpensesAmount");
                }
            }
        }

        public ObservableCollection<AdditionalExpenseCalculator> AdditionalExpenses { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public PriceDetails(ProductPrice productPrice)
        {
            this.productPrice = productPrice;
            TaxAmount = 0;
            DiscountAmount = 0;
            ExpensesAmount = 0;
            AdditionalExpenses = new ObservableCollection<AdditionalExpenseCalculator>();
        }

        public void CalculatePriceDetails(ICalculator calculator)
        {
            if(calculator is TaxCalculator)   
                TaxAmount += calculator.Calculate(productPrice);
            else if (calculator is DiscountCalculator || calculator is AdditionalDiscountCalculator
                || calculator is AdditionalDiscountBeforeTaxCalculator)
            {
                DiscountAmount += calculator.Calculate(productPrice);
            }
            else if(calculator is AdditionalExpenseCalculator)
            {
                ExpensesAmount += calculator.Calculate(productPrice);
                AdditionalExpenses.Add(calculator as AdditionalExpenseCalculator);
            }
        }

        public void Reset()
        {
            TaxAmount = 0;
            DiscountAmount = 0;
            ExpensesAmount = 0;
            AdditionalExpenses.Clear();
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
