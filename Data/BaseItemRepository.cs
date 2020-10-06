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

        public IEnumerable<BaseItem> AllItems
        {
            get
            {
                return _appDbContext.Items.Include(c => c.MainCategory);
            }
        }

        public BaseItem GetItemById(int itemID)
        {
            return _appDbContext.Items.FirstOrDefault(p => p.BaseItemID == itemID);
        }
    }
}
