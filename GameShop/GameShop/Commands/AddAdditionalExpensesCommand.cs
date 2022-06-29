using GameShop.Backend.Model;
using System;
using System.Windows.Input;

namespace GameShop.Commands
{
    public class AddAdditionalExpensesCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public ProductPrice SelectedProductPrice { get; set; }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            AdditionalExpensesWindow additionalExpensesWindow = new AdditionalExpensesWindow(SelectedProductPrice);
            additionalExpensesWindow.ShowDialog();
        }
    }
}
