using GameShop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameShop.Calculators
{
    public interface ICalculator
    {
        public double Calculate(ProductPrice productPrice);
    }
}
