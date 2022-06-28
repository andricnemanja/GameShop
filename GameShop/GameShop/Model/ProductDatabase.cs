using GameShop.Calculators;
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
        
        public ProductDatabase(string fileName)
        {
            Products = new();
            ProductPricesList = new ObservableCollection<ProductPrice>();
            serializationFileName = fileName;
        }

        public void AddProduct(Product product)
        {
            Products.Add(product);
        }

        public void UpdatePrices()
        {
            foreach (ProductPrice productPrice in ProductPricesList)
                productPrice.CalculateFinalPrice();
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
            foreach(Product product in Products)
            {
                ProductPrice productPrice = new ProductPrice(product);
                ProductPricesList.Add(productPrice);
            }
        }
    }
}
