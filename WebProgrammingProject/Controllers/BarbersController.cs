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
    public class BarbersController : Controller
    {
        private readonly Db _context;

        public BarbersController(Db context)
        {
            _context = context;
        }

        // GET: Barbers
        public async Task<IActionResult> Index()
        {
            return View(await _context.Barber_t.ToListAsync());
        }

        // GET: Barbers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var barber = await _context.Barber_t
                .FirstOrDefaultAsync(m => m.Id == id);
            if (barber == null)
            {
                return NotFound();
            }

            return View(barber);
        }

        // GET: Barbers/Create
        public IActionResult Create()
        {
            List<int> sh_ids = (from sh in _context.Shop_t
                    select sh.Id).ToList();

            List<int> p_ids = (from p in _context.Proficiencies_t
                                select p.Id).ToList();
            var proficiencies = new Dictionary<int, string>();
            foreach (var id in p_ids)
            {
                proficiencies.Add(id,(from p in _context.Proficiencies_t where id == p.Id select p.name).FirstOrDefault());
            }
            ViewBag.prof = proficiencies;
            ViewBag.shIds = sh_ids;
            ViewBag.pIds = p_ids;

            var model = new BarberCreateViewModel
            {
                Barber = new Barber(),
                //Proficiencies = proficiencies,
                //ShopIds = sh_ids
            };
            return View(model);
        }

        // POST: Barbers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BarberCreateViewModel model, List<int> SelectedDays)
        {
            //var selectedProficiencyId = 
            //[Bind("Id,FirstName,SurName,Email,Password,StartTime,EndTime")] Barber barber, List<int> SelectedDays, Dictionary<int,string> prof, int ShopId
            /*foreach (var p  in prof)
            {
                // You can now work with the integer values or convert them back to the enum
                barber.Proficiencies.Add(p.Key);
            }
            foreach (var day in SelectedDays)
            {
                // You can now work with the integer values or convert them back to the enum
                DayOfWeekEnum selectedDay = (DayOfWeekEnum)day;
                barber.SelectedDays.Add(selectedDay);
            }*/
            //model.Proficiencies = new Dictionary<int, string>();
            //model.ShopIds = new List<int>();
            //model.Proficiencies = new List<int>();
            Barber newBarber;
            if (ModelState.IsValid)
            {
                // Extract selected ShopId and ProficiencyId from the model
                //var selectedShopId = model.Barber.ShopId;
                //var selectedProficiencyId = model.Proficiencies;

                // Initialize and populate the Barber entity from the model
                newBarber = model.Barber;
                foreach (var day in SelectedDays)
                {
                    // You can now work with the integer values or convert them back to the enum
                    DayOfWeekEnum selectedDay = (DayOfWeekEnum)day;
                    newBarber.SelectedDays.Add(selectedDay);
                }                //newBarber.Proficiencies = selectedProficiencyId;
                                 //_context.Add(barber);
                _context.Add(newBarber);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        // GET: Barbers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            List<int> sh_ids = (from sh in _context.Shop_t
                                select sh.Id).ToList();
            ViewBag.shIds = sh_ids;

            if (id == null)
            {
                return NotFound();
            }

            var barber = await _context.Barber_t.FindAsync(id);
            if (barber == null)
            {
                return NotFound();
            }
            return View(barber);
        }

        // POST: Barbers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ShopId,FirstName,SurName,Email,Password")] Barber barber)
        {
            if (id != barber.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(barber);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BarberExists(barber.Id))
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
            return View(barber);
        }

        // GET: Barbers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var barber = await _context.Barber_t
                .FirstOrDefaultAsync(m => m.Id == id);
            if (barber == null)
            {
                return NotFound();
            }

            return View(barber);
        }

        // POST: Barbers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var barber = await _context.Barber_t.FindAsync(id);
            if (barber != null)
            {
                _context.Barber_t.Remove(barber);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BarberExists(int id)
        {
            return _context.Barber_t.Any(e => e.Id == id);
        }
    }
}
