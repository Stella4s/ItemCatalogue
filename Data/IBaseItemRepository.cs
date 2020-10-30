using ItemCatalogue.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ItemCatalogue.Data
{
    public interface IBaseItemRepository
    {
        Task<IEnumerable<BaseItem>> GetAllItemsAsync();
        Task<IEnumerable<BaseItem>> GetAllItemsAndCompositesAsync();
        Task<BaseItem> GetItemByIdAsync(int itemID);
        Task<BaseItem> GetItemAndCompositesByIdAsync(int itemID);
    }
}
