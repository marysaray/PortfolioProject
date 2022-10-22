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
    public class CelebrationsAndCeremoniesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CelebrationsAndCeremoniesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CelebrationsAndCeremonies
        public async Task<IActionResult> Index()
        {
              return View(await _context.CelebrationsAndCeremonies.ToListAsync());
        }

        // GET: CelebrationsAndCeremonies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.CelebrationsAndCeremonies == null)
            {
                return NotFound();
            }

            var celebrationsAndCeremonies = await _context.CelebrationsAndCeremonies
                .FirstOrDefaultAsync(m => m.Id == id);
            if (celebrationsAndCeremonies == null)
            {
                return NotFound();
            }

            return View(celebrationsAndCeremonies);
        }

        // GET: CelebrationsAndCeremonies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CelebrationsAndCeremonies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,EventName")] CelebrationsAndCeremonies celebrationsAndCeremonies)
        {
            if (ModelState.IsValid)
            {
                _context.Add(celebrationsAndCeremonies);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(celebrationsAndCeremonies);
        }

        // GET: CelebrationsAndCeremonies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.CelebrationsAndCeremonies == null)
            {
                return NotFound();
            }

            var celebrationsAndCeremonies = await _context.CelebrationsAndCeremonies.FindAsync(id);
            if (celebrationsAndCeremonies == null)
            {
                return NotFound();
            }
            return View(celebrationsAndCeremonies);
        }

        // POST: CelebrationsAndCeremonies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,EventName")] CelebrationsAndCeremonies celebrationsAndCeremonies)
        {
            if (id != celebrationsAndCeremonies.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(celebrationsAndCeremonies);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CelebrationsAndCeremoniesExists(celebrationsAndCeremonies.Id))
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
            return View(celebrationsAndCeremonies);
        }

        // GET: CelebrationsAndCeremonies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.CelebrationsAndCeremonies == null)
            {
                return NotFound();
            }

            var celebrationsAndCeremonies = await _context.CelebrationsAndCeremonies
                .FirstOrDefaultAsync(m => m.Id == id);
            if (celebrationsAndCeremonies == null)
            {
                return NotFound();
            }

            return View(celebrationsAndCeremonies);
        }

        // POST: CelebrationsAndCeremonies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.CelebrationsAndCeremonies == null)
            {
                return Problem("Entity set 'ApplicationDbContext.CelebrationsAndCeremonies'  is null.");
            }
            var celebrationsAndCeremonies = await _context.CelebrationsAndCeremonies.FindAsync(id);
            if (celebrationsAndCeremonies != null)
            {
                _context.CelebrationsAndCeremonies.Remove(celebrationsAndCeremonies);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CelebrationsAndCeremoniesExists(int id)
        {
          return _context.CelebrationsAndCeremonies.Any(e => e.Id == id);
        }
    }
}
