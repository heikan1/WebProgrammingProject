using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebProgrammingProject.Models.db;

namespace WebProgrammingProject.Controllers
{
    public class RendezvousController : Controller
    {
        private readonly Db _context;

        public RendezvousController(Db context)
        {
            _context = context;
        }

        // GET: Rendezvous
        public async Task<IActionResult> Index()
        {
            return View(await _context.Rendezvous_t.ToListAsync());
        }

        // GET: Rendezvous/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rendezvous = await _context.Rendezvous_t
                .FirstOrDefaultAsync(m => m.Id == id);
            if (rendezvous == null)
            {
                return NotFound();
            }

            return View(rendezvous);
        }

        // GET: Rendezvous/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Rendezvous/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,When,CustomerId,BarberId")] Rendezvous rendezvous)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rendezvous);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(rendezvous);
        }

        // GET: Rendezvous/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rendezvous = await _context.Rendezvous_t.FindAsync(id);
            if (rendezvous == null)
            {
                return NotFound();
            }
            return View(rendezvous);
        }

        // POST: Rendezvous/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,When,CustomerId,BarberId")] Rendezvous rendezvous)
        {
            if (id != rendezvous.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rendezvous);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RendezvousExists(rendezvous.Id))
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
            return View(rendezvous);
        }

        // GET: Rendezvous/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rendezvous = await _context.Rendezvous_t
                .FirstOrDefaultAsync(m => m.Id == id);
            if (rendezvous == null)
            {
                return NotFound();
            }

            return View(rendezvous);
        }

        // POST: Rendezvous/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var rendezvous = await _context.Rendezvous_t.FindAsync(id);
            if (rendezvous != null)
            {
                _context.Rendezvous_t.Remove(rendezvous);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RendezvousExists(int id)
        {
            return _context.Rendezvous_t.Any(e => e.Id == id);
        }
    }
}
