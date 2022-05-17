using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for AdditionalDiscount.xaml
    /// </summary>
    public partial class AdditionalDiscountWindow : Window
    {
        public double Discount { get; set; }
        private List<Product> products;
        private DataGrid mainWindowDataGrid;
        public AdditionalDiscountWindow(List<Product> selectedProducts, DataGrid dataGrid)
        {
            products = selectedProducts;
            mainWindowDataGrid = dataGrid;
            InitializeComponent();
            this.DataContext = this;
            
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            foreach(Product product in products)
            {
                product.AdditionalDiscountBeforeTax = (bool)DiscountBeforeTaxCheckBox.IsChecked;
                product.UpdateAdditionalDiscount(Discount);
            }
            mainWindowDataGrid.Items.Refresh();
            this.Close();
        }
    }
}
