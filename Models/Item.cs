using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace ItemCatalogue.Models
{
    public class Item
    {
        public int ItemID { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public ItemQuality Quality { get; set; }
        public decimal BasePrice { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public Collection<Category> Categories { get; set; }
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
