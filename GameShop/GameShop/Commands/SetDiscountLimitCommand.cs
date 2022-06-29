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

        private double _discountLimitPercentage;

        public double DiscountLimitPercentage
        {
            get { return _discountLimitPercentage; }
            set 
            { 
                _discountLimitPercentage = value; 
                _discountLimitFixedAmount = 0;
            }
        }

        private double _discountLimitFixedAmount;

        public double DiscountLimitFixedAmount
        {
            get { return _discountLimitFixedAmount; }
            set 
            { 
                _discountLimitFixedAmount = value;
                _discountLimitPercentage = 0;
            }
        }

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
            GlobalSettings.Instance.DiscountLimit = new DiscountLimit(_discountLimitPercentage, _discountLimitFixedAmount);
            productDatabase.UpdatePrices();
            discountLimitWindow.Close();
        }


    }
}
