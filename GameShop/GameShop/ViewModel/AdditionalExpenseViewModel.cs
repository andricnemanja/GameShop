using GameShop.Backend.Model;
using GameShop.Commands;
using System.ComponentModel;

namespace GameShop
{
    public class AdditionalExpenseViewModel : INotifyPropertyChanged
    {
        private string _additionalExpenseName;
        public string AdditionalExpenseName
        {
            get { return _additionalExpenseName; }
            set
            {
                _additionalExpenseName = value;
                SaveAdditionalExpenseCommand.ExpenseName = value;
            }
        }

        private double _pricePercentage = 0;
        public double PricePercentage
        {
            get { return _pricePercentage; }
            set
            {
                if (_pricePercentage != value)
                {
                    _pricePercentage = value;
                    _expenseAmount = 0;
                    RaisePropertyChanged("PricePercentage");
                    RaisePropertyChanged("ExpenseAmount");
                    SaveAdditionalExpenseCommand.PricePercentage = value;
                    SaveAdditionalExpenseCommand.ExpenseAmount = 0; ;
                }
            }
        }

        private double _expenseAmount = 0;
        public double ExpenseAmount
        {
            get { return _expenseAmount; }
            set
            {
                if (_expenseAmount != value)
                {
                    _expenseAmount = value;
                    _pricePercentage = 0;
                    RaisePropertyChanged("PricePercentage");
                    RaisePropertyChanged("ExpenseAmount");
                    SaveAdditionalExpenseCommand.ExpenseAmount = value; ;
                    SaveAdditionalExpenseCommand.PricePercentage = 0;
                }
            }
        }

        public ProductPrice SelectedProductPrice { get; set; }


        public SaveAdditionalExpenseCommand SaveAdditionalExpenseCommand { get; set; }
        public RemoveAdditionalExpenseCommand RemoveAdditionalExpenseCommand { get; set; }


        public AdditionalExpenseViewModel(ProductPrice selectedProductPrice)
        {
            SelectedProductPrice = selectedProductPrice;
            SaveAdditionalExpenseCommand = new SaveAdditionalExpenseCommand(selectedProductPrice);
            RemoveAdditionalExpenseCommand = new RemoveAdditionalExpenseCommand(selectedProductPrice);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }


    }
}
