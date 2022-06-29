using GameShop.Backend;
using GameShop.ViewModel;
using System.Windows;

namespace GameShop
{
    /// <summary>
    /// Interaction logic for AdditionalDiscount.xaml
    /// </summary>
    public partial class DiscountLimitWindow : Window
    {
        public DiscountLimitWindow(ProductDatabase productDatabase)
        {
            InitializeComponent();
            this.DataContext = new DiscountLimitViewModel(this, productDatabase);
        }
    }
}
