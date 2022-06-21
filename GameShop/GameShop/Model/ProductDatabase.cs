using GameShop.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace GameShop
{
    public class ProductDatabase
    {
        public static ObservableCollection<Product> Products { get; set; }
        public ObservableCollection<ProductPrice> ProductPricesList { get; set; }
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

        public static bool IsUPCUnique(int UPC)
        {
            foreach(Product product in Products)
            {
                if (product.UPC == UPC)
                    return false;
            }
            return true;
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
            Products = JsonSerializer.Deserialize<ObservableCollection<Product>>(jsonString);
        }
    }
}
