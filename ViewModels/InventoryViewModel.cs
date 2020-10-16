using ItemCatalogue.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ItemCatalogue.ViewModels
{
    public class InventoryViewModel
    {
        public InvItem SelectedInvItem { get; set; }
        public Inventory Inventory { get; set; }
        public decimal Coin { get; set; }
    }
}
