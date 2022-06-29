using System.Collections.ObjectModel;

namespace GameShop.Backend.Settings
{
    public class ProductSettings
    {
        public bool AdditionalDiscoubtBeforeTax { get; set; }
        public double AdditionalDiscount { get; set; }
        public ObservableCollection<AdditionalExpense> AdditionalExpenses { get; set; }

        public ProductSettings()
        {
            AdditionalExpenses = new ObservableCollection<AdditionalExpense>();
        }
    }
}
