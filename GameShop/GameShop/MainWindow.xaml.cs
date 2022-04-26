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
        private static string PRODUCTS_JSON = @".\..\..\..\Resources\products.json";
        public List<Product> Products { get; set; }
        private readonly ProductDatabase productDatabase;
        private double tax;

        public MainWindow()
        {
            DataContext = this;
            productDatabase = new ProductDatabase(PRODUCTS_JSON) { Tax = 20 };
            productDatabase.Deserialize();
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

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            productDatabase.Serialize();
        }
    }
}
