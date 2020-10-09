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

        public async Task<IEnumerable<InvItem>> GetAllItemsAsync()
        {
            return await _appDbContext.InvItems.Include(c => c.BaseItem).ToListAsync();
        }

        public async Task<InvItem> GetItemByIdAsync(int itemID)
        {
            return await _appDbContext.InvItems.FirstOrDefaultAsync(p => p.InvItemID == itemID);
        }
    }
}
