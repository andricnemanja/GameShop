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

        public AddProductCommand(ProductDatabase productDatabase)
        {
            this.productDatabase = productDatabase;
        }


        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            AddProductWindow addProductWindow = new AddProductWindow(productDatabase);
            addProductWindow.ShowDialog();
        }
    }
}
