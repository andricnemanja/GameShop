using GameShop.Backend;
using GameShop.ViewModel;
using System.Windows;

namespace GameShop
{
    /// <summary>
    /// Interaction logic for AddProductWindow.xaml
    /// </summary>
    public partial class AddProductWindow : Window
    {
        public AddProductWindow(ProductDatabase database)
        {
            InitializeComponent();
            this.DataContext = new AddProductViewModel(database);
        }

    }
}
