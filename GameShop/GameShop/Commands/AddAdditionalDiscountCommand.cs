using GameShop.Backend.Model;
using System;
using System.Windows.Input;

namespace GameShop.Commands
{
    public class AddAdditionalDiscountCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        public ProductPrice SelectedProductPrice { get; set; }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            AdditionalDiscountWindow window = new AdditionalDiscountWindow(SelectedProductPrice);
            window.Show();
        }
    }
}
