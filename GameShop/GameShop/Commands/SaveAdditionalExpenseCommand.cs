using GameShop.Backend.Model;
using GameShop.Backend.Settings;
using System;
using System.Windows.Input;

namespace GameShop.Commands
{
    public class SaveAdditionalExpenseCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        private ProductPrice selectedProductPrice;

        public string ExpenseName { get; set; }
        public double PricePercentage { get; set; }
        public double ExpenseAmount { get; set; }

        public SaveAdditionalExpenseCommand(ProductPrice selectedProductPrice)
        {
            this.selectedProductPrice = selectedProductPrice;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            AdditionalExpense additionalExpense = new AdditionalExpense(ExpenseName, PricePercentage, ExpenseAmount);
            selectedProductPrice.ProductSettings.AdditionalExpenses.Add(additionalExpense);
            selectedProductPrice.CalculateFinalPrice();
        }
    }
}
