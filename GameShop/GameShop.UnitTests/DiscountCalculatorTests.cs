using GameShop.Backend;
using GameShop.Backend.Calculators;
using GameShop.Backend.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GameShop.UnitTests
{
    [TestClass]
    public class DiscountCalculatorTests
    {
        [TestMethod]
        public void CalculateDiscountTest()
        {
            TaxCalculator taxCalculator = new TaxCalculator(21);
            DiscountCalculator discountCalculator = new DiscountCalculator(15);
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
            discountCalculator.Calculate(productPrice);

            Assert.AreEqual(3.0375, productPrice.PriceDetails.DiscountAmount);
        }
    }
}