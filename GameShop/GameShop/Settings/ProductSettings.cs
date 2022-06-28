using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameShop.Settings
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
