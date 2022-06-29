using GameShop.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace GameShop.ViewModel
{
    public class DiscountLimitViewModel
    {
        public ICommand SetDiscountLimitCommand { get; set; }

        public DiscountLimitViewModel(Window discountLimitWindow, ProductDatabase productDatabase)
        {
            SetDiscountLimitCommand = new SetDiscountLimitCommand(discountLimitWindow, productDatabase);
        }
    }
}
