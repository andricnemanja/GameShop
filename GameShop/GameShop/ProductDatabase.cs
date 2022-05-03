using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace GameShop
{
    public class ProductDatabase
    {
        public List<Product> Products { get; set; }
        private string serializationFileName;
        private double _tax;
        public double Tax
        {
            get { return _tax; }
            set
            {
                _tax = value;
                foreach (Product product in Products)
                {
                    product.Update(_tax, _discount);
                }

            }
        }

        private double _discount;

        public double Discount
        {
            get { return _discount; }
            set 
            {      
                _discount = value;
                foreach (Product product in Products)
                {
                    product.Update(_tax, _discount);
                }                
            }
        }

        public ProductDatabase(string fileName)
        {
            Products = new();
            serializationFileName = fileName;
        }

        public void AddProduct(Product product)
        {
            Products.Add(product);
        }

        public void Serialize()
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            string jsonString = JsonSerializer.Serialize(Products, options);
            File.WriteAllText(serializationFileName, jsonString);
        }

        public void Deserialize()
        {
            string jsonString = File.ReadAllText(serializationFileName);
            Products = JsonSerializer.Deserialize<List<Product>>(jsonString);
        }
    }
}
