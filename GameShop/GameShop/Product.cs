﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameShop
{
    public class Product
    {
        public string Name { get; set; }
        public int UPC { get; set; }
        public double Price { get; set; }
        public double PriceWithTax { get; set; }

        public void Update(double newTax)
        {
            PriceWithTax = Math.Round(Price + Price * newTax / 100, 2);
        }
    }
}
