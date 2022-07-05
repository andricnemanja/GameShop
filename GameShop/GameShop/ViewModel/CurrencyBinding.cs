using GameShop.Backend;
using GameShop.Backend.Settings;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameShop.ViewModel
{
    public class CurrencyBinding : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private bool _usd;

        public bool USD
        {
            get { return _usd; }
            set 
            { 
                if(_usd != value)
                {
                    SetAllToFalse();
                    _usd = true;
                    NotifyAll();
                    GlobalSettings.Instance.Currency = Currency.USD;
                }
            }
        }

        private bool _eur;

        public bool EUR
        {
            get { return _eur; }
            set
            {
                if (_eur != value)
                {
                    SetAllToFalse();
                    _eur = true;
                    NotifyAll();
                    GlobalSettings.Instance.Currency = Currency.EUR;
                }
            }
        }

        private bool _rsd;

        public bool RSD
        {
            get { return _rsd; }
            set
            {
                if (_rsd != value)
                {
                    SetAllToFalse();
                    _rsd = true;
                    NotifyAll();
                    GlobalSettings.Instance.Currency = Currency.RSD;
                }
            }
        }

        private bool _gbp;

        public bool GBP
        {
            get { return _gbp; }
            set
            {
                if (_gbp != value)
                {
                    SetAllToFalse();
                    _gbp = true;
                    NotifyAll();
                    GlobalSettings.Instance.Currency = Currency.GBP;

                }
            }
        }

        private bool _jpy;

        public bool JPY
        {
            get { return _jpy; }
            set
            {
                if (_jpy != value)
                {
                    SetAllToFalse();
                    _jpy = true;
                    NotifyAll();
                    GlobalSettings.Instance.Currency = Currency.JPY;

                }
            }
        }

        private bool _chf;

        public bool CHF
        {
            get { return _chf; }
            set
            {
                if (_chf != value)
                {
                    SetAllToFalse();
                    _chf = true;
                    NotifyAll();
                    GlobalSettings.Instance.Currency = Currency.CHF;

                }
            }
        }

        private void NotifyAll()
        {
            RaisePropertyChanged("USD");
            RaisePropertyChanged("EUR");
            RaisePropertyChanged("RSD");
            RaisePropertyChanged("CHF");
            RaisePropertyChanged("GBP");
            RaisePropertyChanged("JPY");
        }

        private void SetAllToFalse()
        {
            _usd = false;
            _eur = false;
            _rsd = false;
            _jpy = false;
            _chf = false;
            _gbp = false;
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
