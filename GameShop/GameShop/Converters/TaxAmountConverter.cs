using System;
using System.Globalization;
using System.Windows.Data;

namespace GameShop.Converters
{
    internal class TaxAmountConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            double amount = (double)value;
            if (amount == 0)
                return "Nema poreza";
            return amount;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string str = value as string;
            if (str.Equals("Nema poreza"))
                return 0;
            return Double.Parse(str);
        }
    }
}
