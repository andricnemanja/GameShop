using GameShop.Backend.Model;
using System.Windows;

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
