using ItemCatalogue.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ItemCatalogue.Data
{
    public interface IBaseItemRepository
    {
        IEnumerable<BaseItem> AllItems { get; }
        BaseItem GetItemById(int itemID);
    }
}
