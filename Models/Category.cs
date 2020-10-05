using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace ItemCatalogue.Models
{
    public class Category
    {
        public int CategoryID { get; set; }
        public string Name { get; set; }
        public Collection<Item> Items{ get; set; }
    }
}
