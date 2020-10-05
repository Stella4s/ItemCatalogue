using ItemCatalogue.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ItemCatalogue.Services
{
    public class InvItemRepository : IInvItemRepository
    {
        private readonly AppDbContext _appDbContext;
        public InvItemRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Item> AllItems
        {
            get
            {
                return _appDbContext.Items.Include(c => c.MainCategory);
            }
        }

        public Item GetItemById(int itemID)
        {
            return _appDbContext.Items.FirstOrDefault(p => p.ItemID == itemID);
        }
    }
}
