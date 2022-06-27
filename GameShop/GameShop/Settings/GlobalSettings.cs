using GameShop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameShop.Settings
{
    public class GlobalSettings
    {
        private static GlobalSettings _instance = null;

        public static GlobalSettings Instance
        {
            get 
            { 
                if( _instance == null )
                    _instance = new GlobalSettings();
                return _instance;
            }
        }

        public double Tax { get; set; }
        public double Discount { get; set; }
        public DiscountType DiscountType { get; set; }

        private GlobalSettings()
        {

        }
    }
}
