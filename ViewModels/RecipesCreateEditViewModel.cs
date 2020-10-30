using ItemCatalogue.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ItemCatalogue.ViewModels
{
    public class RecipesCreateEditViewModel
    {
        public BaseItem MainBaseItem;
        public BaseItem SelectedOptionItem;
        public ItemComposite SelectedIngredientItem;

        public IEnumerable<BaseItem> OptionItems { get; set; }
        public IEnumerable<ItemComposite> IngredientItems { get; set; }
    }
}
