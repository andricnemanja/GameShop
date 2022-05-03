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
        private ProductDatabase productDatabase;
        private DataGrid productsDataGrid;
        private double tax;
        private double discount;

        public string ProductName { get; set; }
        public int UPC { get; set; }
        public double Price { get; set; }

        public AddProductWindow(ProductDatabase database, DataGrid dataGrid, double productTax, double productDiscount)
        {
            InitializeComponent();
            this.DataContext = this;
            productDatabase = database;
            productsDataGrid = dataGrid;
            tax = productTax;
            discount = productDiscount;
            UPC = -1;
            Price = -1;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(ProductName) || Price == -1 || UPC == -1)
            {
                MessageBox.Show("Morate popuniti sva polja");
                return;
            }
            productDatabase.AddProduct(new Product
            {
                Name = ProductName,
                Price = Price,
                UPC = UPC,
            });
            productDatabase.Tax = tax;
            productDatabase.Discount = discount;
            productsDataGrid.Items.Refresh();
            this.Close();
        }
    }
}
