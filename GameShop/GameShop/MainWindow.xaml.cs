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
        private double discount;

        public MainWindow()
        {
            DataContext = this;
            productDatabase = new ProductDatabase(PRODUCTS_JSON) { Tax = 20, Discount = 0 };
            productDatabase.Deserialize();
            Products = ProductDatabase.Products;
            InitializeComponent();
            
        }

        private void TaxInput_TextChanged(object sender, TextChangedEventArgs e)
        {
            double newTax;
            if (!double.TryParse(TaxInput.Text, out newTax))
            {
                TaxInput.Text = String.Empty;
                return;
            }
            productDatabase.Tax = newTax;
            dataGrid.Items.Refresh();
        }

        private void DiscountInput_TextChanged(object sender, TextChangedEventArgs e)
        {
            double newDiscount;
            if (!double.TryParse(DiscountInput.Text, out newDiscount))
            {
                DiscountInput.Text = String.Empty;
                return;
            }
            productDatabase.Discount = newDiscount;
            dataGrid.Items.Refresh();

        }

        private void AddProduct_Click(object sender, RoutedEventArgs e)
        {
            AddProductWindow addProductWindow = new AddProductWindow(productDatabase, dataGrid, tax, discount)
            {
                Owner = this
            };
            addProductWindow.ShowDialog();
        }

        private void RemoveProduct_Click(object sender, RoutedEventArgs e)
        {
            Product productToRemove = (Product)dataGrid.SelectedItem;
            ProductDatabase.Products.Remove(productToRemove);
            dataGrid.Items.Refresh();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            productDatabase.Serialize();
        }

    }
}
