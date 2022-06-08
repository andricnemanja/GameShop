using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace GameShop.Converters
{
    internal class ExpensesAmountConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            double amount = (double)value;
            if (amount == 0)
                return "Nema troškova";
            return amount.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string str = value as string;
            if (str.Equals("Nema troškova"))
                return 0;
            return Double.Parse(str);
        }
    }
}
