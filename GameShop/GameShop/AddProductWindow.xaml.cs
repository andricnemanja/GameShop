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

        public AddProductWindow(ProductDatabase database, DataGrid dataGrid, double productTax)
        {
            InitializeComponent();
            productDatabase = database;
            productsDataGrid = dataGrid;
            tax = productTax;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            productDatabase.AddProduct(new Product
            {
                Name = ProductName.Text,
                Price = double.Parse(PriceWithoutTax.Text),
                UPC = int.Parse(UPCCode.Text),
            });
            productDatabase.Tax = tax;
            productsDataGrid.Items.Refresh();
            this.Close();
        }
    }
}
