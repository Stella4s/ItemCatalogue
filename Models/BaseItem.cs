using ItemCatalogue.Helpers;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


namespace ItemCatalogue.Models
{
    public class BaseItem
    {
        public int BaseItemID { get; set; }
        public string Name { get; set; }

        [DisplayName("Image")]
        public string ImageUrl { get; set; }


        [Column(TypeName = "decimal(18,2)")]
        public decimal BasePrice { get; set; }

        public string Description { get; set; }
        public int CategoryID { get; set; }

        [DisplayName("Category")]
        public Category MainCategory { get; set; }
    }
}


