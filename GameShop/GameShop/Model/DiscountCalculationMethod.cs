using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameShop.Model
{
    public class DiscountCalculationMethod
    {
        private static DiscountCalculationMethod _instance = null;
        public DiscountType DiscountType { get; set; }

        private DiscountCalculationMethod()
        {
            DiscountType = DiscountType.ADDITIVE;
        }

        public static DiscountCalculationMethod Instance
        {
            get {
                if( _instance == null )
                    _instance = new DiscountCalculationMethod();
                return _instance; ; 
            }
        }

    }
}
