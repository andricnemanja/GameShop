using GameShop.Backend;
using GameShop.Backend.Calculators;
using GameShop.Backend.Model;
using GameShop.Backend.Settings;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GameShop.UnitTests
{
    [TestClass]
    public class AdditionalDiscountTests
    {
        [TestMethod]
        public void RegularAdditiveAdditionalDiscount()
        {
            GlobalSettings.Instance.Tax = 21;
            GlobalSettings.Instance.Discount = 15;
            TaxCalculator taxCalculator = new TaxCalculator(21);
            DiscountCalculator discountCalculator = new DiscountCalculator(15);
            AdditionalDiscountCalculator additionalDiscountCalculator = new AdditionalDiscountCalculator(7);
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
            additionalDiscountCalculator.Calculate(productPrice);

            Assert.AreEqual(4.455, productPrice.PriceDetails.DiscountAmount);
        }

        [TestMethod]
        public void RegularMultiplicativeAdditionalDiscount()
        {
            GlobalSettings.Instance.Tax = 21;
            GlobalSettings.Instance.Discount = 15;
            TaxCalculator taxCalculator = new TaxCalculator(21);
            DiscountCalculator discountCalculator = new DiscountCalculator(15);
            AdditionalDiscountCalculator additionalDiscountCalculator = new AdditionalDiscountCalculator(7);
            Product product = new Product()
            {
                Name = "Friends Forest House",
                Price = 20.25,
                UPC = 41679
            };
            GlobalSettings.Instance.DiscountType = DiscountType.MULTIPLICATIVE;
            ProductPrice productPrice = new ProductPrice(product);
            PriceDetails priceDetails = new PriceDetails(productPrice);
            productPrice.PriceDetails = priceDetails;

            taxCalculator.Calculate(productPrice);
            discountCalculator.Calculate(productPrice);
            additionalDiscountCalculator.Calculate(productPrice);

            Assert.AreEqual(4.242375, productPrice.PriceDetails.DiscountAmount);
        }

        [TestMethod]
        public void BeforeTaxAdditiveAdditionalDiscount()
        {
            GlobalSettings.Instance.Tax = 21;
            GlobalSettings.Instance.Discount = 15;
            TaxCalculator taxCalculator = new TaxCalculator(21);
            DiscountCalculator discountCalculator = new DiscountCalculator(15);
            AdditionalDiscountBeforeTaxCalculator additionalDiscountCalculator = new AdditionalDiscountBeforeTaxCalculator(7);
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
            additionalDiscountCalculator.Calculate(productPrice);

            Assert.AreEqual(4.752675, productPrice.PriceDetails.DiscountAmount);
        }

    }
}