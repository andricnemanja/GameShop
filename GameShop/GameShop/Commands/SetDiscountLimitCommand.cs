using GameShop.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace GameShop.Commands
{
    public class SetDiscountLimitCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public double DiscountLimitPercentage { get; set; }

        public double DiscountLimitFixedAmount { get; set; }

        private Window discountLimitWindow;

        private ProductDatabase productDatabase;

        public SetDiscountLimitCommand(Window discountLimitWindow, ProductDatabase productDatabase)
        {
            this.discountLimitWindow = discountLimitWindow;
            this.productDatabase = productDatabase;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            GlobalSettings.Instance.DiscountLimit = new DiscountLimit(DiscountLimitPercentage, DiscountLimitFixedAmount);
            productDatabase.UpdatePrices();
            discountLimitWindow.Close();
        }


    }
}
