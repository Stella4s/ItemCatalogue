using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ItemCatalogue.Data;
using ItemCatalogue.Helpers;
using ItemCatalogue.Models;
using ItemCatalogue.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace ItemCatalogue.Controllers
{
    public class RecipesController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IBaseItemRepository _baseItemRepository;
        private readonly ICategoryRepository _categoryRepository;
        //private readonly Inventory _inventory;

        public RecipesController(AppDbContext context, IBaseItemRepository baseItemRepository, ICategoryRepository categoryRepository)
        {
            _context = context;
            _baseItemRepository = baseItemRepository;
            _categoryRepository = categoryRepository;
            //_inventory = inventory;
        }

        public async Task<IActionResult> Index(int? id)
        {
            //var items = await _inventory.GetInventoryItemsAsync();
            //_inventory.InventoryItems = items;

            var vm = new RecipesIndexViewModel();
            vm.BaseItems = await _baseItemRepository.GetAllItemsAndCompositesAsync();
            //vm.Inventory = _inventory;

            /*First Attempt to combine BaseItems and the amount of items in the inventory.
             * var query = vm.BaseItems.GroupJoin(_inventory.InventoryItems.GroupBy(b => b.BaseItemID),
                         baseItem => baseItem.BaseItemID,
                         invGroup => invGroup.Count(),
                         (baseI, itemCollection) =>
                             new
                             {
                                 baseItemTemp = baseI,
                                 count = itemCollection.Select(t => t.Key)
                             });*/

            if (id != null)
            {
                vm.SelectedBaseItem = vm.BaseItems.Where(i => i.BaseItemID == id.Value).Single();
            }
            return View(vm);
        }

        //GET: Recipes/Edit/5
        public async Task<IActionResult> Edit(int? id, int? selectedID, int? selectedIngredientID)
        {
            if (id == null)
            {
                return NotFound();
            }

            //Also including the composites to later use in the ViewModel.
            var baseItem = await _baseItemRepository.GetItemAndCompositesByIdAsync((int)id);
            if (baseItem == null)
            {
                return NotFound();
            }

            var vm = new RecipesCreateEditViewModel
            {
                MainBaseItem = baseItem,

                //Not using the respository standard get all items call, as I want to not include the item that is being created by this recipe.
                //OptionItems = await _baseItemRepository.GetAllItemsAsync()
                OptionItems = await _context.BaseItems.Where(b => b.BaseItemID != id).Include(c => c.MainCategory).ToListAsync(),

                IngredientItems = baseItem.SubItems
            };

            if (selectedID != null)
            {
                vm.SelectedOptionItem = vm.OptionItems.Where(i => i.BaseItemID == selectedID.Value).Single();
            }
            if(selectedIngredientID != null)
            {
                vm.SelectedIngredientItem = vm.IngredientItems.Where(i => i.SubItemID == selectedIngredientID.Value).Single();
            }

            return View(vm);
        }

        /// <summary>
        /// Adds an ingredient to specified item.
        /// </summary>
        /// <param name="id">ParentItem</param>
        /// <param name="ingredientID">ID for ingredient to be added.</param>
        /// <param name="amount">The amount of the ingredient added.</param>
        /// <returns></returns>
        public async Task<RedirectToActionResult> AddIngredient(int id, int ingredientID, int amount)
        {
            var selectedItem = await _baseItemRepository.GetItemAndCompositesByIdAsync(id);

            if (selectedItem != null)
            {
                //Find the specified ingredient within mainItems subingredients.
                var ingredientIC = selectedItem.SubItems.FirstOrDefault(sb => sb.SubItemID == ingredientID);

                //Check if selectedItem already has that SubItem.
                //If so, add the specified amount to already existing amount.
                //If not, make new ItemComposite.
                if (selectedItem.SubItems.Contains(ingredientIC))
                    ingredientIC.Amount += amount;
                else
                    selectedItem.SubItems.Add(new ItemComposite {SubItemID = ingredientID, Amount = amount });

                _context.Update(selectedItem);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("Edit", new { @id = id });
        }

        public async Task<RedirectToActionResult> RemoveIngredient(int id, int ingredientID, int amount)
        {
            //Take the current main Item.
            var selectedItem = await _baseItemRepository.GetItemAndCompositesByIdAsync(id);

            if (selectedItem != null)
            {
                //Find the specified ingredient within mainItems subingredients.
                var ingredientIC = selectedItem.SubItems.FirstOrDefault(sb => sb.SubItemID == ingredientID);

                //Check if selectedItem has SubItem
                if (selectedItem.SubItems.Contains(ingredientIC))
                {
                    //If there are less than the total ingredients being removed, ajust amount of ingredient used in recipe.
                    //Otherwise remove ingredient from recipe altogether.
                    if (ingredientIC.Amount > amount)
                        ingredientIC.Amount -= amount;
                    else
                        _context.Remove(ingredientIC);
                }
                _context.Update(selectedItem);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("Edit", new { @id = id });
        }

    }
}
