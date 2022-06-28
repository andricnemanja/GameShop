using GameShop.Calculators;
using GameShop.Model;
using GameShop.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GameShop.Commands
{
    public class RemoveAdditionalExpenseCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public ProductPrice SelectedProductPrice { get; set; }
        public AdditionalExpense SelectedExpense { get; set; }

        public RemoveAdditionalExpenseCommand(ProductPrice selectedProductPrice)
        {
            SelectedProductPrice = selectedProductPrice;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            SelectedProductPrice.ProductSettings.AdditionalExpenses.Remove(SelectedExpense) ;
            SelectedProductPrice.CalculateFinalPrice();
        }
    }
}
