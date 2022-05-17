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
    public partial class AdditionalDiscount : Window
    {
        private ProductDatabase productDatabase;
        private DataGrid mainWindowDataGrid;

        public double Discount { get; set; }
        public ObservableCollection<ProductSelection> ProductSelections { get; set; }

        public AdditionalDiscount(ProductDatabase database, DataGrid dataGrid)
        {
            productDatabase = database;
            InitializeComponent();
            this.DataContext = this;
            ProductSelections = new ObservableCollection<ProductSelection>();
            Discount = 0;
            mainWindowDataGrid = dataGrid;

            foreach(Product product in ProductDatabase.Products)
            {
                ProductSelections.Add(new ProductSelection { Product = product });
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            foreach(ProductSelection productSelection in ProductSelections)
            {
                if(productSelection.IsSelected)
                {
                    productSelection.Product.AdditionalDiscountBeforeTax = 
                        (bool)DiscountBeforeTaxCheckBox.IsChecked;
                    productSelection.Product.UpdateAdditionalDiscount(Discount);
                }
            }
            mainWindowDataGrid.Items.Refresh();
            this.Close();
        }

        public class ProductSelection
        {
            public Product Product { get; set; }
            public bool IsSelected { get; set; }

            public ProductSelection()
            {
                IsSelected = false;
            }
        }
    }
}
