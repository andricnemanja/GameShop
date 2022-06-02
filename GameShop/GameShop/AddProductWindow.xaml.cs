using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace GameShop
{
    /// <summary>
    /// Interaction logic for AddProductWindow.xaml
    /// </summary>
    public partial class AddProductWindow : Window
    {
        public ProductDatabase ProductDatabase { get; set; }
        private double tax;
        private double discount;

        public string ProductName { get; set; }
        public int UPC { get; set; }
        public double Price { get; set; }

        public AddProductWindow(ProductDatabase database, double productTax, double productDiscount)
        {
            InitializeComponent();
            this.DataContext = this;
            ProductDatabase = database;
            tax = productTax;
            discount = productDiscount;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            ProductDatabase.AddProduct(new Product
            {
                Name = ProductName,
                Price = Price,
                UPC = UPC,
            });
            ProductDatabase.Tax = tax;
            ProductDatabase.Discount = discount;
            this.Close();
        }
    }
}
