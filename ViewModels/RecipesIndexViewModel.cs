using ItemCatalogue.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ItemCatalogue.ViewModels
{
    public class RecipesIndexViewModel
    {
        public BaseItem SelectedBaseItem { get; set; }
        public IEnumerable<BaseItem> BaseItems { get; set; }
    }
}
