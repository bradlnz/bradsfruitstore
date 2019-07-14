using System;
using System.Collections.Generic;
using System.Text;

namespace BradsFruitStore.Models
{
    public class ProductModel
    {
        public string ProductCode { get; set; }
        public decimal PricePerItem { get; set; }
        public decimal PriceAtVolume { get; set; }
        public ProductSaleType SaleType { get; set; }
        public int VolumeThreshold { get; set; }
        public int ScannedQuantity { get; set; }
    }
}
