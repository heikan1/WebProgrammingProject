using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebProgrammingProject.Models;
using WebProgrammingProject.Models.db;

namespace WebProgrammingProject.Controllers
{
    [Authorize(Roles = "A")]
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
            return View(await _context.Shop_t.ToListAsync());
        }

        // GET: Shops/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shop = await _context.Shop_t
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
            List<int> sh_ids = (from sh in _context.Shopkeeper_t
                             select sh.Id).ToList();
            ViewBag.shIds = sh_ids;
            var model = new Shop();
            return View(model);
        }

        // POST: Shops/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,Address,ShopkeeperId,StartTime,EndTime,City")] Shop shop, List<int> SelectedDays)
        {
            //burayi bayagi bi elden gecirmek lazim ya offff
            foreach (var day in SelectedDays)
            {
                // You can now work with the integer values or convert them back to the enum
                DayOfWeekEnum selectedDay = (DayOfWeekEnum)day;
                shop.SelectedDays.Add(selectedDay);
            }
                if (ModelState.IsValid)
            {
                _context.Add(shop);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(shop);
        }

        // GET: Shops/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            List<int> sh_ids = (from sh in _context.Shopkeeper_t
                                select sh.Id).ToList();
            ViewBag.shIds = sh_ids;
            if (id == null)
            {
                return NotFound();
            }

            var shop = await _context.Shop_t.FindAsync(id);
            if (shop == null)
            {
                return NotFound();
            }
            return View(shop);
        }

        // POST: Shops/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,Address,ShopkeeperId,StartTime,EndTime,City")] Shop shop, List<int> SelectedDays)
        {
            if (id != shop.Id)
            {
                return NotFound();
            }
            foreach (var day in SelectedDays)
            {
                // You can now work with the integer values or convert them back to the enum
                DayOfWeekEnum selectedDay = (DayOfWeekEnum)day;
                shop.SelectedDays.Add(selectedDay);
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
