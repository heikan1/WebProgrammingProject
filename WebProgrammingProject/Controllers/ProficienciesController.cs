using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebProgrammingProject.Models.db;

namespace WebProgrammingProject.Controllers
{
    [Authorize(Roles = "A")]
    public class ProficienciesController : Controller
    {
        private readonly Db _context;

        public ProficienciesController(Db context)
        {
            _context = context;
        }

        // GET: Proficiencies
        public async Task<IActionResult> Index()
        {
            return View(await _context.Proficiencies_t.ToListAsync());
        }

        // GET: Proficiencies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var proficiencies = await _context.Proficiencies_t
                .FirstOrDefaultAsync(m => m.Id == id);
            if (proficiencies == null)
            {
                return NotFound();
            }

            return View(proficiencies);
        }

        // GET: Proficiencies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Proficiencies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,name,price")] Proficiencies proficiencies)
        {
            if (ModelState.IsValid)
            {
                _context.Add(proficiencies);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(proficiencies);
        }

        // GET: Proficiencies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var proficiencies = await _context.Proficiencies_t.FindAsync(id);
            if (proficiencies == null)
            {
                return NotFound();
            }
            return View(proficiencies);
        }

        // POST: Proficiencies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,name,price")] Proficiencies proficiencies)
        {
            if (id != proficiencies.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(proficiencies);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProficienciesExists(proficiencies.Id))
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
            return View(proficiencies);
        }

        // GET: Proficiencies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var proficiencies = await _context.Proficiencies_t
                .FirstOrDefaultAsync(m => m.Id == id);
            if (proficiencies == null)
            {
                return NotFound();
            }

            return View(proficiencies);
        }

        // POST: Proficiencies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var proficiencies = await _context.Proficiencies_t.FindAsync(id);
            if (proficiencies != null)
            {
                _context.Proficiencies_t.Remove(proficiencies);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProficienciesExists(int id)
        {
            return _context.Proficiencies_t.Any(e => e.Id == id);
        }
    }
}
