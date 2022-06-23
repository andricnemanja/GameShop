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
    public class SaveProductCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private ProductDatabase productDatabase;

        public string ProductName { get; set; }
        public int UPC { get; set; }
        public double Price { get; set; }

        public SaveProductCommand(ProductDatabase productDatabase)
        {
            this.productDatabase = productDatabase;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            Product newProduct = new Product()
            {
                Name = ProductName,
                Price = Price,
                UPC = UPC
            };
            ProductPrice productPrice = new ProductPrice(newProduct);
            productPrice.Calculators.Add(TaxCalculator.Instance);
            productPrice.Calculators.Add(DiscountCalculator.Instance);
            productDatabase.ProductPricesList.Add(productPrice);
            ProductDatabase.Products.Add(newProduct);
        }
    }
}
