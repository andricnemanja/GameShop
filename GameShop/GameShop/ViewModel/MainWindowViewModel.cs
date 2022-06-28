using GameShop.Calculators;
using GameShop.Commands;
using GameShop.Model;
using GameShop.Settings;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GameShop
{

    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private static string PRODUCTS_JSON = @".\..\..\..\Resources\products.json";
        public ObservableCollection<ProductPrice> ProductPricesList{ get; set; }
        private ProductDatabase productDatabase;

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

        private double _tax = 20;
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

        private double _discount = 0;
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

        private bool _additiveDiscount = true;
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

        private bool _multiplicativeDiscount = false;
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


        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand AddProductCommand { get; set; }
        public BaseCommand RemoveProductCommand { get; set; }
        public ICommand AdditionalDiscountCommand { get; set; }
        public ICommand AdditionalExpenseCommand { get; set; }


        public MainWindowViewModel()
        {
            productDatabase = new ProductDatabase(PRODUCTS_JSON);
            productDatabase.Deserialize();
            ProductPricesList = productDatabase.ProductPricesList;

            AddProductCommand = new AddProductCommand(productDatabase);
            RemoveProductCommand = new BaseCommand(RemoveProductExecuteMethod);
            AdditionalDiscountCommand = new AddAdditionalDiscountCommand();
            AdditionalExpenseCommand = new AddAdditionalExpensesCommand();
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
    }
}
