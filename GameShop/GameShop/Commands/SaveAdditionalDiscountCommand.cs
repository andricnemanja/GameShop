using GameShop.Backend.Model;
using System;
using System.Windows.Input;

namespace GameShop.Commands
{
    public class SaveAdditionalDiscountCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private ProductPrice selectedProductPrice;
        public double DiscountPercentage { get; set; }
        public bool DiscountBeforeTax { get; set; }

        private AdditionalDiscountWindow additionalDiscountWindow;


        public SaveAdditionalDiscountCommand(ProductPrice selectedProductPrice, AdditionalDiscountWindow window)
        {
            this.selectedProductPrice = selectedProductPrice;
            this.additionalDiscountWindow = window;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            selectedProductPrice.ProductSettings.AdditionalDiscoubtBeforeTax = DiscountBeforeTax;
            selectedProductPrice.ProductSettings.AdditionalDiscount = DiscountPercentage;
            selectedProductPrice.CalculateFinalPrice();

            additionalDiscountWindow.Close();


        }
    }
}
