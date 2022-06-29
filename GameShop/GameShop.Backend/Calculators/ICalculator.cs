using GameShop.Backend.Model;

namespace GameShop.Backend.Calculators
{
    public interface ICalculator
    {
        public void Calculate(ProductPrice productPrice);
    }
}
