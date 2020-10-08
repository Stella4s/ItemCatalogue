using ItemCatalogue.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ItemCatalogue.Models
{
    public class InvItem
    {
        private decimal _Price;

        public int InvItemID { get; set; }

        public int BaseItemID { get; set; }
        public BaseItem BaseItem { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Price 
        { 
            get { return CalculatePrice(BaseItem.BasePrice, Quality); }
            set { _Price = value; }
        }

        public ItemQuality Quality { get; set; }

        public string InventoryID { get; set; }

        public InvItem()
        {
            Quality = ItemQuality.Basic;   
        }

        public decimal CalculatePrice(decimal basePrice, ItemQuality quality)
        {
            return basePrice * QualityToNumber(quality);
        }

        public decimal QualityToNumber(ItemQuality quality)
        {
            var modifier = quality switch
            {
                ItemQuality.Basic => 1,
                ItemQuality.Nice => 1.25M,
                ItemQuality.Good => 1.5M,
                ItemQuality.Excellent => 1.75M,
                ItemQuality.Exceptional => 2.0M,
                ItemQuality.Poor => 0.8M,
                _ => 1,
            };
            return modifier;
        }
    }
}
public enum ItemQuality
{
    Basic,
    Nice,
    Good,
    Excellent,
    Exceptional,
    Poor
}