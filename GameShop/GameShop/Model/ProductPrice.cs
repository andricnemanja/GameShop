using GameShop.Calculators;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameShop.Model
{
    public class ProductPrice : INotifyPropertyChanged
    {
        public Product Product { get; set; }
        public List<ICalculator> Calculators { get; set; }

        private double _finalPrice;
        public double FinalPrice
        {
            get { return _finalPrice; }
            set 
            { 
                if (_finalPrice != value)
                {
                    _finalPrice = value;
                    RaisePropertyChanged("FinalPrice");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public ProductPrice(Product product)
        {
            Product = product;
            Calculators = new List<ICalculator>();
            FinalPrice = product.Price;
        }


        public double CalculateFinalPrice()
        {
            FinalPrice = Product.Price;

            foreach (ICalculator calculator in Calculators)
            {
                FinalPrice += calculator.Calculate(this);
            }

            return FinalPrice;
        }

        public void AddCalculator(ICalculator calculator)
        {
            Calculators.Add(calculator);
            CalculateFinalPrice();
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
