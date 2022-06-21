using GameShop.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GameShop
{

    public class MainWindowCommands
    {
        private static string PRODUCTS_JSON = @".\..\..\..\Resources\products.json";
        public ObservableCollection<Product> Products { get; set; }
        private ProductDatabase productDatabase;
    
        public Product SelectedProduct { get; set; }
        public ICommand AddProductCommand { get; set; }
        public BaseCommand RemoveProductCommand { get; set; }
        public BaseCommand AdditionalDiscountCommand { get; set; }
        public BaseCommand AdditionalExpenseCommand { get; set; }

        private double _tax = 20;
        public double Tax
        {
            get { return _tax; }
            set 
            {
                _tax = value;
                if (_tax < 0)
                {
                    _tax = 0;
                }
                else
                {
                    productDatabase.Tax = _tax;
                }
                
            }
        }

        private double _discount = 0;
        public double Discount
        {
            get { return _discount; }
            set
            {
                _discount = value;
                if (_discount < 0)
                {
                    _discount = 0;
                }
                else
                {
                    productDatabase.Discount = _discount;
                }

            }
        }

        public MainWindowCommands()
        {
            productDatabase = new ProductDatabase(PRODUCTS_JSON) { Tax = 20, Discount = 0 };
            productDatabase.Deserialize();
            Products = ProductDatabase.Products;
            AddProductCommand = new AddProductCommand(productDatabase, Tax, Discount);
            RemoveProductCommand = new BaseCommand(RemoveProductExecuteMethod);
            AdditionalDiscountCommand = new BaseCommand(AdditionalDiscountExecuteMethod);
            AdditionalExpenseCommand = new BaseCommand(AdditionalExpenseExecuteMethod);
        }

        private void RemoveProductExecuteMethod()
        {
            ProductDatabase.Products.Remove(SelectedProduct);
            productDatabase.Serialize();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            productDatabase.Serialize();
        }


        private void AdditionalDiscountExecuteMethod()
        {
            List<Product> selectedProducts = GetSelectedProducts();

            if (selectedProducts.Count == 0)
            {
                AdditionalDiscount additionalDiscount = new AdditionalDiscount(productDatabase);
                additionalDiscount.ShowDialog();
                return;
            }

            AdditionalDiscountWindow additionalDiscountWindow = new AdditionalDiscountWindow(selectedProducts);
            additionalDiscountWindow.ShowDialog();
        }

        private List<Product> GetSelectedProducts()
        {
            List<Product> selectedProducts = new List<Product>();
            selectedProducts.Add(SelectedProduct);
            return selectedProducts;
        }

        private void AdditionalExpenseExecuteMethod()
        {
            AdditionalExpensesWindow additionalExpensesWindow = new AdditionalExpensesWindow(SelectedProduct);
            additionalExpensesWindow.ShowDialog();
        }


    }
}
