using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ItemCatalogue.Models
{
    public class InvItem
    {
        public int InvItemID { get; set; }

        public int BaseItemID { get; set; }
        public BaseItem BaseItem { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        public ItemQuality Quality { get; set; }

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