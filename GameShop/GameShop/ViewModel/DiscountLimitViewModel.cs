using GameShop.Commands;
using GameShop.Settings;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace GameShop.ViewModel
{
    public class DiscountLimitViewModel : INotifyPropertyChanged
    {
        private double _discountLimitPercentage;

        public double DiscountLimitPercentage
        {
            get { return _discountLimitPercentage; }
            set 
            { 
                if( _discountLimitPercentage != value)
                {
                    _discountLimitPercentage = value;
                    _discountLimitFixedAmount = 0;
                    RaisePropertyChanged("DiscountLimitFixedAmount");
                    UpdateDiscountLimitCommandProperties();
                    
                }
            }
        }

        private double _discountLimitFixedAmount;

        public double DiscountLimitFixedAmount
        {
            get { return _discountLimitFixedAmount; }
            set 
            {
                if (_discountLimitFixedAmount != value)
                {
                    _discountLimitFixedAmount = value;
                    _discountLimitPercentage = 0;
                    RaisePropertyChanged("DiscountLimitPercentage");
                    UpdateDiscountLimitCommandProperties();

                }
            }
        }

        public SetDiscountLimitCommand SetDiscountLimitCommand { get; set; }

        public DiscountLimitViewModel(Window discountLimitWindow, ProductDatabase productDatabase)
        {
            SetDiscountLimitCommand = new SetDiscountLimitCommand(discountLimitWindow, productDatabase);
        }

        private void UpdateDiscountLimitCommandProperties()
        {
            SetDiscountLimitCommand.DiscountLimitFixedAmount = _discountLimitFixedAmount;
            SetDiscountLimitCommand.DiscountLimitPercentage = _discountLimitPercentage; 
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }

    }
}
