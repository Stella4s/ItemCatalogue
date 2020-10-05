using ItemCatalogue.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ItemCatalogue.Services
{
    public interface IInvItemRepository
    {
        IEnumerable<Item> AllItems { get; }
        Item GetItemById(int itemID);
    }
}
