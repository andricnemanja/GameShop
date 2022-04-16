using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameShop
{
    class ProductDatabase
    {
        public List<Product> Products { get; set; }
        private double _tax;
        public double Tax
        {
            get { return _tax; }
            set
            {
                _tax = value;
                foreach (Product product in Products)
                {
                    product.Update(_tax);
                }

            }
        }

        public ProductDatabase()
        {
            Products = new();
        }

        public void AddProduct(Product product)
        {
            Products.Add(product);
        }
    }
}
