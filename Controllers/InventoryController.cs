﻿using System;
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
        public async Task<ActionResult> Index()
        {
            var items = await _inventory.GetInventoryItemsAsync();
            _inventory.InventoryItems = items;

            var inventoryViewModel = new InventoryViewModel
            {
                Inventory = _inventory,
                Coin = _inventory.Coin
            };

            return View(inventoryViewModel);
        }

        public async Task<RedirectToActionResult> AddToInventory(int bItemID, int? amount)
        {
            int itemAmount = 1;
            if (amount.HasValue)
                itemAmount = (int)amount;

            var selectedItem = await _baseItemRepository.GetItemByIdAsync(bItemID);

            if (selectedItem != null)
            {
                await _inventory.AddToInventoryAsync(selectedItem, itemAmount);
            }
            return RedirectToAction("Index");
        }


        public async Task<RedirectToActionResult> RemoveFromInventory(int itemID)
        {
            var selectedItem = await _invItemRepository.GetItemByIdAsync(itemID);

            if (selectedItem != null)
            {
                await _inventory.RemoveFromInventoryAsync(selectedItem);
            }
            return RedirectToAction("Index");
        }

    }
}
