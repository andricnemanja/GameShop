using GameShop.Backend;
using System;
using System.Windows.Input;

namespace GameShop.Commands
{
    public class DiscountLimitCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private ProductDatabase productDatabase;

        public DiscountLimitCommand(ProductDatabase productDatabase)
        {
            this.productDatabase = productDatabase;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            DiscountLimitWindow discountLimitWindow = new DiscountLimitWindow(productDatabase);
            discountLimitWindow.Show();
        }
    }
}
