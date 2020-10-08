using ItemCatalogue.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ItemCatalogue.Data
{
    public interface IInvItemRepository
    {
        Task<IEnumerable<InvItem>> GetAllItemsAsync();
        Task<InvItem> GetItemByIdAsync(int itemID);
    }
}
