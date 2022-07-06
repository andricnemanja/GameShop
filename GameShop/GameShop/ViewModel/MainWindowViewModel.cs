using GameShop.Backend;
using GameShop.Backend.Model;
using GameShop.Backend.Settings;
using GameShop.Commands;
using GameShop.ViewModel;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace GameShop
{

    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private static string PRODUCTS_JSON = @".\..\..\..\Resources\products.json";
        private static string GLOBAL_SETTINGS_JSON = @".\..\..\..\Resources\settings.json";

        public ObservableCollection<ProductPrice> ProductPricesList { get; set; }
        private ProductDatabase productDatabase;
        private GlobalSettingsDatabase globalSettingsDatabase;

        private ProductPrice _selectedProductPrice;
        public ProductPrice SelectedProductPrice
        {
            get { return _selectedProductPrice; }
            set
            {
                _selectedProductPrice = value;
                ((AddAdditionalDiscountCommand)AdditionalDiscountCommand).SelectedProductPrice = value;
                ((AddAdditionalExpensesCommand)AdditionalExpenseCommand).SelectedProductPrice = value;
            }
        }

        private double _tax;
        public double Tax
        {
            get { return _tax; }
            set
            {
                _tax = value;
                if (_tax < 0)
                {
                    _tax = 0;
                }
                else
                {
                    GlobalSettings.Instance.Tax = _tax;
                    productDatabase.UpdatePrices();
                }

            }
        }

        private double _discount;
        public double Discount
        {
            get { return _discount; }
            set
            {
                _discount = value;
                if (_discount < 0)
                {
                    _discount = 0;
                }
                else
                {
                    GlobalSettings.Instance.Discount = _discount;
                    productDatabase.UpdatePrices();
                }

            }
        }

        private bool _additiveDiscount;
        public bool AdditiveDiscount
        {
            get { return _additiveDiscount; }
            set
            {
                if (_additiveDiscount != value)
                {
                    _additiveDiscount = value;
                    _multiplicativeDiscount = !value;
                    RaisePropertyChanged("AdditiveDiscount");
                    RaisePropertyChanged("MultiplicativeDiscount");

                    ChangeDiscountType();
                }
            }
        }

        private bool _multiplicativeDiscount;
        public bool MultiplicativeDiscount
        {
            get { return _multiplicativeDiscount; }
            set
            {
                if (_multiplicativeDiscount != value)
                {
                    _multiplicativeDiscount = value;
                    _additiveDiscount = !value;
                    RaisePropertyChanged("AdditiveDiscount");
                    RaisePropertyChanged("MultiplicativeDiscount");

                    ChangeDiscountType();
                }
            }
        }

        public CurrencyBinding CurrencyBinding { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand AddProductCommand { get; set; }
        public BaseCommand RemoveProductCommand { get; set; }
        public ICommand AdditionalDiscountCommand { get; set; }
        public ICommand AdditionalExpenseCommand { get; set; }
        public ICommand DiscountLimitCommand { get; set; }

        public MainWindowViewModel()
        {
            productDatabase = new ProductDatabase(PRODUCTS_JSON);
            globalSettingsDatabase = new GlobalSettingsDatabase(GLOBAL_SETTINGS_JSON);
            productDatabase.Deserialize();
            globalSettingsDatabase.Deserialize();
            productDatabase.UpdatePrices();
            ProductPricesList = productDatabase.ProductPricesList;
            CurrencyBinding = new CurrencyBinding();
            UpdateViewValues();

            AddProductCommand = new AddProductCommand(productDatabase);
            RemoveProductCommand = new BaseCommand(RemoveProductExecuteMethod);
            AdditionalDiscountCommand = new AddAdditionalDiscountCommand();
            AdditionalExpenseCommand = new AddAdditionalExpensesCommand();
            DiscountLimitCommand = new DiscountLimitCommand(productDatabase);
        }

        private void UpdateViewValues()
        {
            _tax = GlobalSettings.Instance.Tax;
            _discount = GlobalSettings.Instance.Discount;
            _additiveDiscount = (GlobalSettings.Instance.DiscountType == DiscountType.ADDITIVE) ? true : false;
            _multiplicativeDiscount = (GlobalSettings.Instance.DiscountType == DiscountType.MULTIPLICATIVE) ? true : false;
            switch (GlobalSettings.Instance.Currency)
            {
                case Currency.USD:
                    CurrencyBinding.USD = true;
                    break;
                case Currency.EUR:
                    CurrencyBinding.EUR = true;
                    break;
                case Currency.GBP:
                    CurrencyBinding.GBP = true;
                    break;
                case Currency.CHF:
                    CurrencyBinding.CHF = true;
                    break;
                case Currency.JPY:
                    CurrencyBinding.JPY = true;
                    break;
                default:
                    CurrencyBinding.RSD = true;
                    break;
            }
        }

        private void ChangeDiscountType()
        {
            if (_additiveDiscount == true)
                GlobalSettings.Instance.DiscountType = DiscountType.ADDITIVE;
            else
                GlobalSettings.Instance.DiscountType = DiscountType.MULTIPLICATIVE;

            productDatabase.UpdatePrices();
        }

        private void RemoveProductExecuteMethod()
        {
            productDatabase.Serialize();
        }

        private void RaisePropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }

        public void OnWindowClosing(object sender, CancelEventArgs e)
        {
            productDatabase.Serialize();
            globalSettingsDatabase.Serialize();
        }

    }
}
