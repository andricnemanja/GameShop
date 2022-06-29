﻿using GameShop.Backend.Model;

namespace GameShop.Backend.Settings
{
    public class GlobalSettings
    {
        private static GlobalSettings _instance = null;

        public static GlobalSettings Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new GlobalSettings();
                return _instance;
            }
        }

        public double Tax { get; set; }
        public double Discount { get; set; }
        public DiscountType DiscountType { get; set; }
        public DiscountLimit DiscountLimit { get; set; }


        private GlobalSettings()
        {
            DiscountLimit = new DiscountLimit(0, 0);
        }
    }
}
