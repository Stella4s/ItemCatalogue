using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ItemCatalogue.Models
{
    public class Item
    {
        public int ItemID { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }


        [Column(TypeName = "decimal(18,2)")]
        public decimal BasePrice { get; set; }

        public string Description { get; set; }
        public int CategoryID { get; set; }
        public Category MainCategory { get; set; }
    }
}


