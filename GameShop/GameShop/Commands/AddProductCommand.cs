using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GameShop.Commands
{
    public class AddProductCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private ProductDatabase productDatabase;
        private double tax;
        private double discount;

        public AddProductCommand(ProductDatabase productDatabase, double tax, double discount)
        {
            this.productDatabase = productDatabase;
            this.tax = tax;
            this.discount = discount;
        }


        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            AddProductWindow addProductWindow = new AddProductWindow(productDatabase, tax, discount);
            addProductWindow.ShowDialog();
        }
    }
}
