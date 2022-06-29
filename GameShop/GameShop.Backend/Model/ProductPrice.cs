using GameShop.Backend.Builder;
using GameShop.Backend.Calculators;
using GameShop.Backend.Settings;
using System.ComponentModel;

namespace GameShop.Backend.Model
{
    public class ProductPrice : INotifyPropertyChanged
    {
        public Product Product { get; set; }
        public PriceDetails PriceDetails { get; set; }
        public ProductSettings ProductSettings { get; set; }
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
            PriceDetails = new PriceDetails(this);
            ProductSettings = new ProductSettings();
        }


        public double CalculateFinalPrice()
        {
            GetCalculators();
            FinalPrice = Product.Price;
            PriceDetails.Reset();

            foreach (ICalculator calculator in Calculators)
            {
                calculator.Calculate(this);
            }

            return FinalPrice;
        }

        private void GetCalculators()
        {
            CalculatorsBuilder calculatorsBuilder = new CalculatorsBuilder(ProductSettings);
            CalculatorsDirector calculatorsDirector = new CalculatorsDirector(calculatorsBuilder);

            calculatorsDirector.BuildCalculators();
            Calculators = calculatorsDirector.GetCalculators();
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
