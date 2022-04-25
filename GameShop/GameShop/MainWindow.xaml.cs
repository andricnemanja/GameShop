using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GameShop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<Product> Products { get; set; }
        private readonly ProductDatabase productDatabase;
        private double tax;

        public MainWindow()
        {
            DataContext = this;
            productDatabase = new ProductDatabase{ Tax = 20 };
            LoadProducts(productDatabase);
            Products = productDatabase.Products;
            InitializeComponent();
            
        }

        private void TaxInput_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                tax = Convert.ToDouble(TaxInput.Text);
                productDatabase.Tax = tax;
                dataGrid.Items.Refresh();
            }
            catch (Exception)
            {
                TaxInput.Text = ".0";
            }
        }

        private void LoadProducts(ProductDatabase productDatabase)
        {
            productDatabase.AddProduct(new Product
            {
                Name = "Fifa 2022",
                UPC = 1000,
                Price = 4999.99
            });
            productDatabase.AddProduct(new Product
            {
                Name = "Pro Evolution Soccer 2022",
                UPC = 1001,
                Price = 3999.99
            });
        }

        private void AddProduct_Click(object sender, RoutedEventArgs e)
        {
            AddProductWindow addProductWindow = new AddProductWindow(productDatabase, dataGrid, tax);
            addProductWindow.Show();
        }

        private void RemoveProduct_Click(object sender, RoutedEventArgs e)
        {
            Product productToRemove = (Product)dataGrid.SelectedItem;
            productDatabase.Products.Remove(productToRemove);
            dataGrid.Items.Refresh();
        }
    }
}
