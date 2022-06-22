using GameShop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GameShop.Commands
{
    public class AddAdditionalDiscountCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        public ProductPrice SelectedProductPrice { get; set; }

        public AddAdditionalDiscountCommand(ProductPrice selectedProductPrice)
        {

        }

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
