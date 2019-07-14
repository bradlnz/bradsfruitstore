using BradsFruitStore.Models;
using BradsFruitStore.Terminal;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BradsFruitStore.TerminalApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
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
            await terminal.ScanProductAsync("A");
            await terminal.ScanProductAsync("B");
            await terminal.ScanProductAsync("C");
            await terminal.ScanProductAsync("D");
            await terminal.ScanProductAsync("A");
            await terminal.ScanProductAsync("B");
            await terminal.ScanProductAsync("A");

            var total = await terminal.CalculateTotalAsync();

            Console.WriteLine(total);
            Console.ReadLine();

        }
    }
}
