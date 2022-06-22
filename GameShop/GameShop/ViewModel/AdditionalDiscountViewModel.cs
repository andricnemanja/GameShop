using GameShop.Commands;
using GameShop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GameShop.ViewModel
{
    public class AdditionalDiscountViewModel
    {
        public ICommand SaveAdditionalDiscountCommand{ get; set; }

        public AdditionalDiscountViewModel(ProductPrice selectedProductPrice, AdditionalDiscountWindow window)
        {
            SaveAdditionalDiscountCommand = new SaveAdditionalDiscountCommand(selectedProductPrice, window);
        }
    }
}
