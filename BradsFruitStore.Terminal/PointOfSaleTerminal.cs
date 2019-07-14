using BradsFruitStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BradsFruitStore.Terminal
{
    public class PointOfSaleTerminal
    {
        private IAsyncEnumerable<ProductModel> ShoppingCart { get; set; }

        public void SetPricing(ProductModel[] products)
        {
            if (products == null)
            {
                throw new ArgumentNullException("Products must be set");
            }
            if (products.Length <= 0)
            {
                throw new Exception("Must contain products");
            }

            ShoppingCart = products.ToAsyncEnumerable();
        }

        public async Task ScanProductAsync(string productCode)
        {
            var product = await ShoppingCart
                    .First(prod => prod.ProductCode == productCode);

            product.ScannedQuantity += 1;
        }

        public async Task<decimal> CalculateTotalAsync()
        {
             decimal total = 0m;

             await ShoppingCart.ForEachAsync(item =>
             {
                  total += item.CalculateTotalForProduct();
             });

            return total;
        }
    }
}
