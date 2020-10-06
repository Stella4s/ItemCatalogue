using ItemCatalogue.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ItemCatalogue.Data
{
    public class InvItemRepository : IInvItemRepository
    {
        private readonly AppDbContext _appDbContext;
        public InvItemRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<InvItem> AllItems
        {
            get
            {
                return _appDbContext.InvItems.Include(c => c.BaseItem);
            }
        }

        public InvItem GetItemById(int itemID)
        {
            return _appDbContext.InvItems.FirstOrDefault(p => p.InvItemID == itemID);
        }
    }
}
