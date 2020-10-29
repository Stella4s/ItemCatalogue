﻿using ItemCatalogue.Models;
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
        
    }
}
