using GameShop.Backend.Model;
using GameShop.ViewModel;
using System.Windows;

namespace GameShop
{
    /// <summary>
    /// Interaction logic for AdditionalDiscount.xaml
    /// </summary>
    public partial class AdditionalDiscountWindow : Window
    {
        public AdditionalDiscountWindow(ProductPrice selectedProductPrice)
        {
            InitializeComponent();
            this.DataContext = new AdditionalDiscountViewModel(selectedProductPrice, this);
        }
    }
}
