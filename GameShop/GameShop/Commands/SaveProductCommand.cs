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
        private string productName;
        private int UPC;
        private double price;

        public SaveProductCommand(string productName, int uPC, double price, ProductDatabase productDatabase)
        {
            this.productName = productName;
            UPC = uPC;
            this.price = price;
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
                Name = productName,
                Price = price,
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
