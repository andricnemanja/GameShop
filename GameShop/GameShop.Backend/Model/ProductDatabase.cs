using GameShop.Backend.Model;
using System.Collections.ObjectModel;
using System.Text.Json;

namespace GameShop.Backend
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
            foreach (Product product in Products)
            {
                if (product.UPC == UPC)
                    return false;
            }
            return true;
        }

        public void Serialize()
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            string jsonString = JsonSerializer.Serialize(ProductPricesList, options);
            File.WriteAllText(serializationFileName, jsonString);
        }

        public void Deserialize()
        {
            string jsonString = File.ReadAllText(serializationFileName);
            ProductPricesList = JsonSerializer.Deserialize<ObservableCollection<ProductPrice>>(jsonString);
        }
    }
}
