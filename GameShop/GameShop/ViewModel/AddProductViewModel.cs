using GameShop.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GameShop.ViewModel
{
    public class AddProductViewModel
    {
        public ICommand SaveProductCommand { get; set; }

        public AddProductViewModel(ProductDatabase productDatabase)
        {
            SaveProductCommand = new SaveProductCommand(productDatabase);
        }
    }
}
