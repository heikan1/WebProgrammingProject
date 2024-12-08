using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using WebProgrammingProject.Models.db;

namespace WebProgrammingProject.Controllers
{
    public class ShopsController : Controller
    {
        private readonly Db _context;

        public ShopsController(Db context)
        {
            _context = context;
        }

        // GET: Shops
        public async Task<IActionResult> Index()
        {
            var db = _context.Shop_t.Include(s => s.shopkeeper);
            return View(await db.ToListAsync());
        }

        // GET: Shops/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shop = await _context.Shop_t
                .Include(s => s.shopkeeper)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (shop == null)
            {
                return NotFound();
            }

            return View(shop);
        }

        // GET: Shops/Create
        public IActionResult Create()
        {
            ViewData["ShopkeeperId"] = new SelectList(_context.Shopkeeper_t, "Id", "Id");
            return View();
        }

        // POST: Shops/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,Address,ShopkeeperId")] Shop shop)
        {
            var shopkeeper = _context.Shopkeeper_t.Where(p => p.Id==shop.ShopkeeperId).FirstOrDefault();
            if (shopkeeper == null) {
                //hata mesaji gonderirim vs
                return View(shop);
            }
            if (ModelState.IsValid)
            {
                _context.Add(shop);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ShopkeeperId"] = new SelectList(_context.Shopkeeper_t, "Id", "Id", shop.ShopkeeperId);
            return View(shop);
        }

        // GET: Shops/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shop = await _context.Shop_t.FindAsync(id);
            if (shop == null)
            {
                return NotFound();
            }
            ViewData["ShopkeeperId"] = new SelectList(_context.Shopkeeper_t, "Id", "Id", shop.ShopkeeperId);
            return View(shop);
        }

        // POST: Shops/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,Address,ShopkeeperId")] Shop shop)
        {
            if (id != shop.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(shop);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ShopExists(shop.Id))
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
            ViewData["ShopkeeperId"] = new SelectList(_context.Shopkeeper_t, "Id", "Id", shop.ShopkeeperId);
            return View(shop);
        }

        // GET: Shops/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shop = await _context.Shop_t
                .Include(s => s.shopkeeper)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (shop == null)
            {
                return NotFound();
            }

            return View(shop);
        }

        // POST: Shops/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var shop = await _context.Shop_t.FindAsync(id);
            if (shop != null)
            {
                _context.Shop_t.Remove(shop);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ShopExists(int id)
        {
            return _context.Shop_t.Any(e => e.Id == id);
        }
    }
}
