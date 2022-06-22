using GameShop.Calculators;
using GameShop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            selectedProductPrice.AddCalculator(new AdditionalExpenseCalculator()
            {
                Amount = ExpenseAmount,
                PricePercentage = PricePercentage,
                Name = ExpenseName
            });
        }
    }
}
