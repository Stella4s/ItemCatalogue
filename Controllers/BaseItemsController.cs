using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ItemCatalogue.Data;
using ItemCatalogue.Models;

namespace ItemCatalogue.Controllers
{
    public class BaseItemsController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IBaseItemRepository _baseItemRepository;

        public BaseItemsController(AppDbContext context, IBaseItemRepository baseItemRepository)
        {
            _context = context;
            _baseItemRepository = baseItemRepository;
        }

        // GET: BaseItems
        public async Task<IActionResult> Index()
        {
            var appDbContext = await _baseItemRepository.GetAllItemsAsync();
            return View(appDbContext);
        }

        // GET: BaseItems/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            /*var baseItem = await _context.BaseItems
                .Include(b => b.MainCategory)
                .FirstOrDefaultAsync(m => m.BaseItemID == id);*/
            
            var baseItem = await _baseItemRepository.GetItemByIdAsync((int)id);
            
            if (baseItem == null)
            {
                return NotFound();
            }

            return View(baseItem);
        }

        // GET: BaseItems/Create
        public IActionResult Create()
        {
            ViewData["CategoryID"] = new SelectList(_context.Categories, "CategoryID", "Name");
            return View();
        }

        // POST: BaseItems/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BaseItemID,Name,ImageUrl,BasePrice,Description,CategoryID")] BaseItem baseItem)
        {
            if (ModelState.IsValid)
            {
                _context.Add(baseItem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryID"] = new SelectList(_context.Categories, "CategoryID", "Name", baseItem.CategoryID);
            return View(baseItem);
        }

        // GET: BaseItems/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var baseItem = await _context.BaseItems.FindAsync(id);
            var baseItem = await _baseItemRepository.GetItemByIdAsync((int)id);
            if (baseItem == null)
            {
                return NotFound();
            }
            ViewData["CategoryID"] = new SelectList(_context.Categories, "CategoryID", "Name", baseItem.CategoryID);
            return View(baseItem);
        }

        // POST: BaseItems/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BaseItemID,Name,ImageUrl,BasePrice,Description,CategoryID")] BaseItem baseItem)
        {
            if (id != baseItem.BaseItemID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(baseItem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BaseItemExists(baseItem.BaseItemID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryID"] = new SelectList(_context.Categories, "CategoryID", "Name", baseItem.CategoryID);
            return View(baseItem);
        }

        // GET: BaseItems/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            /*var baseItem = await _context.BaseItems
                .Include(b => b.MainCategory)
                .FirstOrDefaultAsync(m => m.BaseItemID == id);*/
            var baseItem = await _baseItemRepository.GetItemByIdAsync((int)id);
            if (baseItem == null)
            {
                return NotFound();
            }

            return View(baseItem);
        }

        // POST: BaseItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            //var baseItem = await _context.BaseItems.FindAsync(id);
            var baseItem = await _baseItemRepository.GetItemByIdAsync((int)id);
            _context.BaseItems.Remove(baseItem);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BaseItemExists(int id)
        {
            return _context.BaseItems.Any(e => e.BaseItemID == id);
        }
    }
}
