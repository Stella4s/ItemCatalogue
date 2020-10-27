using ItemCatalogue.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ItemCatalogue.ViewModels
{
    public class BaseItemsCreateEditViewModel
    {
        public BaseItem BaseItem;

        public IEnumerable<SelectListItem> Categories;

        public IEnumerable<SelectListItem> Images;
    }
}
