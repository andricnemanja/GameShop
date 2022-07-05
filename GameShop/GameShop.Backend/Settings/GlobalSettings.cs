using GameShop.Backend.Model;
using System.ComponentModel;

namespace GameShop.Backend.Settings
{
    public class GlobalSettings : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private static GlobalSettings _instance = null;

        public static GlobalSettings Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new GlobalSettings();
                return _instance;
            }
        }

        public double Tax { get; set; }
        public double Discount { get; set; }
        public DiscountType DiscountType { get; set; }
        public DiscountLimit DiscountLimit { get; set; }
        private Currency _currency;

        public Currency Currency
        {
            get { return _currency; }
            set 
            { 
                if( _currency != value)
                {
                    _currency = value;
                    RaisePropertyChanged("Currency");
                } 
            }
        }



        private GlobalSettings()
        {
            DiscountLimit = new DiscountLimit(0, 0);
        }


        private void RaisePropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }
    }
}
