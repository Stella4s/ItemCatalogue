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
        public ActionResult Index()
        {
            //var items = _inventory.GetInventoryItems();
            //_inventory.InventoryItems = items;

            var items = _inventory.GetInventoryItemsAsync();
            _inventory.InventoryItems = items.Result;

            var inventoryViewModel = new InventoryViewModel
            {
                Inventory = _inventory,
                Coin = _inventory.Coin
            };

            return View(inventoryViewModel);
        }



        public RedirectToActionResult AddToInventory(int bItemID)
        {
            var selectedItem = _baseItemRepository.AllItems.FirstOrDefault(i => i.BaseItemID == bItemID);

            if (selectedItem != null)
            {
                _inventory.AddToInventory(selectedItem, 1);
            }
            return RedirectToAction("Index");
        }

        public RedirectToActionResult RemoveFromInventory(int itemID)
        {
            var selectedItem = _invItemRepository.AllItems.FirstOrDefault(i => i.InvItemID == itemID);

            if (selectedItem != null)
            {
                _inventory.RemoveFromInventory(selectedItem);
            }
            return RedirectToAction("Index");
        }


        /*
        // GET: InventoryController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: InventoryController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }*/
    }
}
