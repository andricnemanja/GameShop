using GameShop.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameShop
{
    public class AdditionalExpenseWindowCommands : INotifyPropertyChanged
    {
        public string AdditionalExpenseName { get; set; }

        private double _pricePercentage = 0;
        public double PricePercentage
        {
            get { return _pricePercentage; }
            set 
            {
                if (_pricePercentage != value)
                {
                    _pricePercentage = value;
                    _expenseAmount = 0;
                    RaisePropertyChanged("PricePercentage");
                    RaisePropertyChanged("ExpenseAmount");
                }
            }
        }

        private double _expenseAmount = 0;
        public double ExpenseAmount
        {
            get { return _expenseAmount; }
            set 
            { 
                if (_expenseAmount != value)
                {
                    _expenseAmount = value;
                    _pricePercentage = 0;
                    RaisePropertyChanged("PricePercentage");
                    RaisePropertyChanged("ExpenseAmount");
                }
            }
        }

        public Product SelectedProduct { get; set; }

        public AdditionalExpense SelectedExpense { get; set; }

        public BaseCommand SaveAdditionalExpenseCommand { get; set; }
        public BaseCommand RemoveAdditionalExpenseCommand { get; set; }


        public AdditionalExpenseWindowCommands(Product selectedProduct)
        {
            SelectedProduct = selectedProduct;
            SaveAdditionalExpenseCommand = new BaseCommand(SaveAdditionalExpenseExecuteMethod);
            RemoveAdditionalExpenseCommand = new BaseCommand(RemoveAdditionalExpenseExecuteMethod);
        }


        private void SaveAdditionalExpenseExecuteMethod()
        {
            SelectedProduct.AddExpense(new AdditionalExpense()
            {
                Name = AdditionalExpenseName,
                Amount = _expenseAmount,
                PricePercentage = _pricePercentage
            }) ;
        }
        private void RemoveAdditionalExpenseExecuteMethod()
        {
            SelectedProduct.RemoveExpense(SelectedExpense);
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
