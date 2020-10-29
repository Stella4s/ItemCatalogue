using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ItemCatalogue.Data;
using ItemCatalogue.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ItemCatalogue.Controllers
{
    public class RecipesController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IBaseItemRepository _baseItemRepository;
        private readonly ICategoryRepository _categoryRepository;

        public RecipesController(AppDbContext context, IBaseItemRepository baseItemRepository, ICategoryRepository categoryRepository)
        {
            _context = context;
            _baseItemRepository = baseItemRepository;
            _categoryRepository = categoryRepository;

        }

        public async Task<IActionResult> Index(int? id)
        {
            var vm = new RecipesIndexViewModel();
            vm.BaseItems = await _baseItemRepository.GetAllItemsAndCompositesAsync();

            if (id != null)
            {
                vm.SelectedBaseItem = vm.BaseItems.Where(i => i.BaseItemID == id.Value).Single();
            }
            return View(vm);
        }
    }
}
