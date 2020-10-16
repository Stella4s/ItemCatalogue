using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ItemCatalogue.Data;
using ItemCatalogue.Models;
using ItemCatalogue.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ItemCatalogue.Controllers
{
    public class InventoryController : Controller
    {
        private readonly IBaseItemRepository _baseItemRepository;
        private readonly IInvItemRepository _invItemRepository;
        private readonly Inventory _inventory;

        public InventoryController(IBaseItemRepository baseItemRepository, IInvItemRepository invItemRepository, Inventory inventory)
        {
            _baseItemRepository = baseItemRepository;
            _invItemRepository = invItemRepository;
            _inventory = inventory;
        }

        // GET: InventoryController
        public async Task<IActionResult> Index(int? id)
        {
            var items = await _inventory.GetInventoryItemsAsync();
            _inventory.InventoryItems = items;

            var vm = new InventoryViewModel
            {
                Inventory = _inventory,
                Coin = _inventory.Coin
            };

            if (id.HasValue)
            {
                vm.SelectedInvItem = vm.Inventory.InventoryItems.Where(i => i.InvItemID == id.Value).Single();
            }

            return View(vm);
        }

        public async Task<RedirectToActionResult> AddToInventory(int id, int? amount)
        {
            int itemAmount = 1;
            if (amount.HasValue)
                itemAmount = (int)amount;

            var selectedItem = await _baseItemRepository.GetItemByIdAsync(id);

            if (selectedItem != null)
            {
                await _inventory.AddToInventoryAsync(selectedItem, itemAmount);
            }
            return RedirectToAction("Index");
        }


        public async Task<RedirectToActionResult> RemoveFromInventory(int id)
        {
            //var selectedItem = await _invItemRepository.GetItemByIdAsync(id);
            
            await _inventory.RemoveFromInventoryAsync(id);
            
            return RedirectToAction("Index");
        }

        /// <summary>
        /// Removes the specified amount of selected BaseItem from the inventory.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="amount"></param>
        /// <returns></returns>
        public async Task<RedirectToActionResult> RemoveBaseItemFromInventory(int id, int? amount)
        {
            int itemAmount = 1;
            if (amount.HasValue)
                itemAmount = (int)amount;
            
            await _inventory.RemoveBaseItemFromInventoryAsync(id, itemAmount);

            return RedirectToAction("Index");
        }

    }
}
