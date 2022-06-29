using GameShop.Backend;
using GameShop.Backend.Calculators;
using GameShop.Backend.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GameShop.UnitTests
{
    [TestClass]
    public class TaxCalculatorTests
    {
        [TestMethod]
        public void CalculateTaxTest()
        {
            TaxCalculator taxCalculator = new TaxCalculator(20);
            Product product = new Product()
            {
                Name = "Friends Forest House",
                Price = 20.25,
                UPC = 41679
            };
            ProductPrice productPrice = new ProductPrice(product);
            PriceDetails priceDetails = new PriceDetails(productPrice);
            productPrice.PriceDetails = priceDetails;


            taxCalculator.Calculate(productPrice);

            Assert.AreEqual(productPrice.PriceDetails.TaxAmount, 4.05);
        }
    }
}