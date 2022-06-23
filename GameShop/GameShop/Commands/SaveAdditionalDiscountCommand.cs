using GameShop.Calculators;
using GameShop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            ICalculator calculator;
            if (DiscountBeforeTax)
                calculator = new AdditionalDiscountBeforeTaxCalculator(DiscountPercentage);
            else
                calculator = new AdditionalDiscountCalculator(DiscountPercentage);

            for(int i = 0;  i < selectedProductPrice.Calculators.Count; i++)
            {
                if(selectedProductPrice.Calculators[i] is AdditionalDiscountBeforeTaxCalculator ||
                    selectedProductPrice.Calculators[i] is AdditionalDiscountCalculator)
                {
                    selectedProductPrice.Calculators[i] = calculator;
                    selectedProductPrice.CalculateFinalPrice();
                    additionalDiscountWindow.Close();
                    return;
                }
            }
            selectedProductPrice.AddCalculator(calculator);
            additionalDiscountWindow.Close();


        }
    }
}
