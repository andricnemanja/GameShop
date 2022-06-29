using GameShop.Backend;
using GameShop.Commands;
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
