using GameShop.Backend.Model;
using GameShop.Commands;
using System.Windows.Input;

namespace GameShop.ViewModel
{
    public class AdditionalDiscountViewModel
    {
        public ICommand SaveAdditionalDiscountCommand { get; set; }

        public AdditionalDiscountViewModel(ProductPrice selectedProductPrice, AdditionalDiscountWindow window)
        {
            SaveAdditionalDiscountCommand = new SaveAdditionalDiscountCommand(selectedProductPrice, window);
        }
    }
}
