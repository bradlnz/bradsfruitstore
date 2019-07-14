using BradsFruitStore.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BradsFruitStore.Terminal
{
    public static class CalculationHelper
    {
        public static decimal CalculateTotalForProduct(this ProductModel product)
        {
            decimal total = 0m;

            if (product.SaleType == ProductSaleType.FlatRateAndVolumePricing
                     && product.ScannedQuantity >= product.VolumeThreshold)
            {
                var divisedAmountAtVolume = product.ScannedQuantity / product.VolumeThreshold;

                if (divisedAmountAtVolume >= 1)
                {
                    total += product.PriceAtVolume * divisedAmountAtVolume;
                    product.ScannedQuantity -= product.VolumeThreshold;

                    while (product.ScannedQuantity > 0)
                    {
                        total += product.PricePerItem;
                        product.ScannedQuantity -= product.VolumeThreshold;
                    }
                }
                else
                {
                    total += product.PriceAtVolume;
                }
            }
            else
            {
                total += product.PricePerItem * product.ScannedQuantity;
            }

            return total;
        }
    }
}
