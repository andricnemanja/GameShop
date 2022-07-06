using System.Windows;
using System.Windows.Input;

namespace GameShop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainWindowViewModel viewModel = new MainWindowViewModel();
            this.DataContext = viewModel;
            Closing += viewModel.OnWindowClosing;
        }

        private void dataGrid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            dataGrid.SelectedItem = null;
        }

    }
}
