using GameShop.Model;
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
    public partial class AdditionalExpensesWindow : Window
    {
        public AdditionalExpensesWindow(ProductPrice selectedProductPrice)
        {
            InitializeComponent();
            this.DataContext = new AdditionalExpenseViewModel(selectedProductPrice);
        }
    }
}
