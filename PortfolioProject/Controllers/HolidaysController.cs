using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PortfolioProject.Data;
using PortfolioProject.Models;

namespace PortfolioProject.Controllers
{
    public class HolidaysController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HolidaysController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Holidays
        public async Task<IActionResult> Index()
        {
              return View(await _context.Holidays.ToListAsync());
        }

        // GET: Holidays/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Holidays == null)
            {
                return NotFound();
            }

            var holidays = await _context.Holidays
                .FirstOrDefaultAsync(m => m.Id == id);
            if (holidays == null)
            {
                return NotFound();
            }

            return View(holidays);
        }

        // GET: Holidays/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Holidays/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,HolidayName")] Holidays holidays)
        {
            if (ModelState.IsValid)
            {
                _context.Add(holidays);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(holidays);
        }

        // GET: Holidays/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Holidays == null)
            {
                return NotFound();
            }

            var holidays = await _context.Holidays.FindAsync(id);
            if (holidays == null)
            {
                return NotFound();
            }
            return View(holidays);
        }

        // POST: Holidays/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,HolidayName")] Holidays holidays)
        {
            if (id != holidays.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(holidays);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HolidaysExists(holidays.Id))
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
            return View(holidays);
        }

        // GET: Holidays/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Holidays == null)
            {
                return NotFound();
            }

            var holidays = await _context.Holidays
                .FirstOrDefaultAsync(m => m.Id == id);
            if (holidays == null)
            {
                return NotFound();
            }

            return View(holidays);
        }

        // POST: Holidays/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Holidays == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Holidays'  is null.");
            }
            var holidays = await _context.Holidays.FindAsync(id);
            if (holidays != null)
            {
                _context.Holidays.Remove(holidays);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HolidaysExists(int id)
        {
          return _context.Holidays.Any(e => e.Id == id);
        }
    }
}