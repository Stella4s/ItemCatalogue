using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ItemCatalogue.Models
{
    public class ItemComposite
    {
        public int ResultItemID { get; set; }
        /// <summary>
        /// The resulting item made from the subitem.
        /// </summary>
        public BaseItem ResultItem { get; set; }
        public int SubItemID { get; set; }
        /// <summary>
        /// The item made into the resulting item.
        /// </summary>
        public BaseItem SubItem { get; set; }

        /// <summary>
        /// For specifing the amount of the SubItem used. Eg. 1 or 2 apples.
        /// </summary>
        public int Amount { get; set; }
    }
}
