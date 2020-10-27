using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ItemCatalogue.Models
{
    public class CompositeItem
    {
        public int ParentItemID { get; set; }
        public BaseItem ParentItem { get; set; }
        public int ChildItemID { get; set; }
        public BaseItem ChildItem { get; set; }

        /// <summary>
        /// For specifing the amount of the ChildItem used. Eg. 1 or 2 apples.
        /// </summary>
        public int Amount { get; set; }
    }
}
