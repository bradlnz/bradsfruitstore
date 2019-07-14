using BradsFruitStore.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace BradsFruitStore.Terminal.Tests
{
    [TestClass]
    public class PointOfSaleTerminalTests
    {
        [TestMethod]
        public async Task Test_First_Sequence_ABCDABA_NotNull_Equals_Thirteen_Dollars_Twenty_Five_Cents()
        {
            //Arrange
            var products = new ProductModel[]
             {
                 new ProductModel
                 {
                ProductCode = "A",
                    PricePerItem = 1.25m,
                    PriceAtVolume = 3.00m,
                    VolumeThreshold = 3,
                    SaleType = ProductSaleType.FlatRateAndVolumePricing
                 },
                 new ProductModel
                 {
                ProductCode = "B",
                    PricePerItem = 4.25m,
                    SaleType = ProductSaleType.FlatRate
                 },
                 new ProductModel
                 {
                ProductCode = "C",
                    PricePerItem = 1.00m,
                    PriceAtVolume = 5.00m,
                    VolumeThreshold = 6,
                    SaleType = ProductSaleType.FlatRateAndVolumePricing
                 },
                 new ProductModel
                 {
                ProductCode = "D",
                    PricePerItem = 0.75m,
                    SaleType = ProductSaleType.FlatRate
                 },
             };

            var terminal = new PointOfSaleTerminal();
            terminal.SetPricing(products);

            //Act
            await terminal.ScanProductAsync("A");
            await terminal.ScanProductAsync("B");
            await terminal.ScanProductAsync("C");
            await terminal.ScanProductAsync("D");
            await terminal.ScanProductAsync("A");
            await terminal.ScanProductAsync("B");
            await terminal.ScanProductAsync("A");

            var total = await terminal.CalculateTotalAsync();

            //Assert

            Assert.IsNotNull(total);
            Assert.AreEqual(13.25m, total);
        }

        [TestMethod]
        public async Task Test_First_Sequence_CCCCCCC_NotNull_Equals_Six_Dollars()
        {
            //Arrange
            var products = new ProductModel[]
             {
                 new ProductModel
                 {
                ProductCode = "A",
                    PricePerItem = 1.25m,
                    PriceAtVolume = 3.00m,
                    VolumeThreshold = 3,
                    SaleType = ProductSaleType.FlatRateAndVolumePricing
                 },
                 new ProductModel
                 {
                ProductCode = "B",
                    PricePerItem = 4.25m,
                    SaleType = ProductSaleType.FlatRate
                 },
                 new ProductModel
                 {
                ProductCode = "C",
                    PricePerItem = 1.00m,
                    PriceAtVolume = 5.00m,
                    VolumeThreshold = 6,
                    SaleType = ProductSaleType.FlatRateAndVolumePricing
                 },
                 new ProductModel
                 {
                ProductCode = "D",
                    PricePerItem = 0.75m,
                    SaleType = ProductSaleType.FlatRate
                 },
             };

            var terminal = new PointOfSaleTerminal();
            terminal.SetPricing(products);

            //Act
            await terminal.ScanProductAsync("C");
            await terminal.ScanProductAsync("C");
            await terminal.ScanProductAsync("C");
            await terminal.ScanProductAsync("C");
            await terminal.ScanProductAsync("C");
            await terminal.ScanProductAsync("C");
            await terminal.ScanProductAsync("C");

            var total = await terminal.CalculateTotalAsync();

            //Assert

            Assert.IsNotNull(total);
            Assert.AreEqual(6m, total);
        }

        [TestMethod]
        public async Task Test_First_Sequence_ABCD_NotNull_Equals_Seven_Dollars_Twenty_Five_Cents()
        {
            //Arrange
            var products = new ProductModel[]
             {
                 new ProductModel
                 {
                ProductCode = "A",
                    PricePerItem = 1.25m,
                    PriceAtVolume = 3.00m,
                    VolumeThreshold = 3,
                    SaleType = ProductSaleType.FlatRateAndVolumePricing
                 },
                 new ProductModel
                 {
                ProductCode = "B",
                    PricePerItem = 4.25m,
                    SaleType = ProductSaleType.FlatRate
                 },
                 new ProductModel
                 {
                ProductCode = "C",
                    PricePerItem = 1.00m,
                    PriceAtVolume = 5.00m,
                    VolumeThreshold = 6,
                    SaleType = ProductSaleType.FlatRateAndVolumePricing
                 },
                 new ProductModel
                 {
                ProductCode = "D",
                    PricePerItem = 0.75m,
                    SaleType = ProductSaleType.FlatRate
                 },
             };

            var terminal = new PointOfSaleTerminal();
            terminal.SetPricing(products);

            //Act
           await terminal.ScanProductAsync("A");
           await terminal.ScanProductAsync("B");
           await terminal.ScanProductAsync("C");
           await terminal.ScanProductAsync("D");

            var total = await terminal.CalculateTotalAsync();

            //Assert

            Assert.IsNotNull(total);
            Assert.AreEqual(7.25m, total);
        }
    }
}
