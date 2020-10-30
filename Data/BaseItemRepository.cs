using ItemCatalogue.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ItemCatalogue.Data
{
    public class BaseItemRepository : IBaseItemRepository
    {
        private readonly AppDbContext _appDbContext;
        public BaseItemRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<IEnumerable<BaseItem>> GetAllItemsAsync()
        {
            return await _appDbContext.BaseItems.Include(c => c.MainCategory).ToListAsync();
        }
        public async Task<IEnumerable<BaseItem>> GetAllItemsAndCompositesAsync()
        {
            return await _appDbContext.BaseItems.Include(c => c.MainCategory)
                .Include(c => c.ResultItems).ThenInclude(c => c.ResultItem)
                .Include(c => c.SubItems).ThenInclude(c => c.SubItem)
                .ToListAsync();
        }

        public async Task<BaseItem> GetItemByIdAsync(int itemID)
        {
            return await _appDbContext.BaseItems.FirstOrDefaultAsync(p => p.BaseItemID == itemID);
        }

        public async Task<BaseItem> GetItemAndCompositesByIdAsync(int itemID)
        {
            //First method
            return await _appDbContext.BaseItems
                .Include(s => s.ResultItems)
                .ThenInclude(ic => ic.ResultItem)
                .Include(s => s.SubItems)
                .ThenInclude(ic => ic.SubItem)
                .FirstOrDefaultAsync(p => p.BaseItemID == itemID);

            //Second "cleaner?" method. But this only returns a projection, not an actual baseItem instance.
            /*var ItemWithComp = _appDbContext.BaseItems.Where(b => b.BaseItemID == itemID)
                .Select(s => new
                {
                    BaseItem = s,
                    ResultItems = s.ResultItems.Select(ic => ic.ResultItem),
                    SubItems = s.SubItems.Select(ic => ic.SubItem)
                })
                .FirstOrDefaultAsync();*/
        }

        public async Task<IEnumerable<BaseItem>> GetAllRecipeItemsAsync()
        {
            return await _appDbContext.BaseItems.Include(c => c.MainCategory)
               .Include(c => c.SubItems).ThenInclude(c => c.SubItem)
               .ToListAsync();
        }
    }
    
}
