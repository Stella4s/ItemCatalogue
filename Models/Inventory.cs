using ItemCatalogue.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ItemCatalogue.Models
{
    public class Inventory
    {
        private readonly AppDbContext _appDbContext;

        public string InventoryID { get; set; }

        public decimal Coin { get; set; }

        public List<InvItem> InventoryItems { get; set; }

        private Inventory(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        //Used actual session ids.
        /*
        /// <summary>
        /// Checks if this session already has an Inventory. If so returns that inventory, if not creates a new Inventory for it.
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static Inventory GetInventory(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?
                .HttpContext.Session;

            var context = services.GetService<AppDbContext>();

            string inventoryID = session.GetString("InventoryID") ?? Guid.NewGuid().ToString();

            session.SetString("InventoryID", inventoryID);

            return new Inventory(context) { InventoryID = inventoryID };
        }*/

        /// <summary>
        /// Sets the InventoryID at the start of each session to 1.
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static Inventory GetInventory(IServiceProvider services)
        {
            string inventoryID = "1";

            var context = services.GetService<AppDbContext>();

            return new Inventory(context) { InventoryID = inventoryID };
        }

        /// <summary>
        /// Creates new InvItems using the specified BaseItem and adds them to the Inventory.
        /// </summary>
        /// <param name="bItem">BaseItem the InvItems will be based on.</param>
        /// <param name="amount">Amount of InvItems to add.</param>
        public void AddToInventory(BaseItem bItem, int amount)
        {
            //Make new InvItems based on the passed BaseItem.
            //Looping through to create as many as the amount requires.
            for (int i = 0; i < amount; i++)
            {
                var inventoryItem = new InvItem
                {
                    InventoryID = InventoryID,
                    BaseItem = bItem,
                    Quality = ItemQuality.Good
                };
                _appDbContext.InvItems.Add(inventoryItem);
            }

            _appDbContext.SaveChanges();
        }

        /// <summary>
        /// Removes a specified InvItem from the Inventory.
        /// </summary>
        /// <param name="iItem">InvItem</param>
        public void RemoveFromInventory(InvItem iItem)
        {
            var invItem =
                _appDbContext.InvItems.SingleOrDefault(
                    s => s.InvItemID == iItem.InvItemID);

            if (invItem != null)
            {
                _appDbContext.InvItems.Remove(invItem);
            }

            _appDbContext.SaveChanges();
        }

        /// <summary>
        /// Removes a set amount of BaseItems from the inventory. If there are enough of them present in the current inventory.
        /// </summary>
        /// <param name="bItem">Specified BaseItem</param>
        /// <param name="amount">Amount to remove</param>
        public void RemoveFromInventory(BaseItem bItem, int amount)
        {
            //Find all InvItems that are the right BaseItem and are from this Inventory.
            //Put them in a list Ordered by Price.
            var invItems =
                _appDbContext.InvItems.Where(
                    s => s.BaseItem.BaseItemID == bItem.BaseItemID && s.InventoryID == InventoryID)
                .OrderBy(s => s.Price)
                .ToList();

            if (invItems != null)
            {
                //Check if there are enough items to remove.
                if (invItems.Count >= amount)
                {
                    //Use for-loop to remove the specified amount of InvItems.
                    //Starting with the first, meaning it removes from highest to lowest price.
                    for(int i = 0; i < amount; i++)
                    {
                        _appDbContext.InvItems.Remove(invItems.FirstOrDefault());
                    }
                }
            }

            _appDbContext.SaveChanges();
        }

        /// <summary>
        /// Checks if the InventoryItems were already retrieved. If not, retrieves them.
        /// </summary>
        /// <returns>CurrentSession InventoryItems</returns>
        public List<InvItem> GetInventoryItems()
        {
            return InventoryItems ??
                (InventoryItems =
                _appDbContext.InvItems.Where(c => c.InventoryID == InventoryID)
                .Include(s => s.BaseItem)
                .ToList());   
        }
        public async Task<List<InvItem>> GetInventoryItemsAsync()
        {
            return InventoryItems ??
                   (InventoryItems = await
                   _appDbContext.InvItems.Where(c => c.InventoryID == InventoryID)
                   .Include(s => s.BaseItem)
                   .ToListAsync());
        }

        /// <summary>
        /// Removes all items from Inventory.
        /// </summary>
        public void ClearInventory()
        {
            var invItems = _appDbContext
                .InvItems
                .Where(inv => inv.InventoryID == InventoryID);

            _appDbContext.InvItems.RemoveRange(invItems);

            _appDbContext.SaveChanges();
        }
    }
}
