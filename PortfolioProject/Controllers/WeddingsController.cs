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
    /// <summary>
    /// The controller for the wedding page.
    /// </summary>
    public class WeddingsController : Controller
    {
        // field
        private readonly ApplicationDbContext _context;

        // constructor injection: inject services
        public WeddingsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Weddings
        /// <summary>
        /// Displays a view of all occasions.
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Index()
        {
              return View(await _context.Love.ToListAsync());
        }

        // GET: Weddings/Details/5
        /// <summary>
        /// Displays data associated to the specific id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Love == null)
            {
                return NotFound();
            }

            var wedding = await _context.Love
                .FirstOrDefaultAsync(m => m.Id == id);
            if (wedding == null)
            {
                return NotFound();
            }

            return View(wedding);
        }

        // GET: Weddings/Create
        /// <summary>
        /// Create a new upload.
        /// </summary>
        /// <returns></returns>
        public IActionResult Create()
        {
            return View();
        }

        // POST: Weddings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        /// <summary>
        /// Add and save to database after validation.
        /// </summary>
        /// <param name="wedding"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Date")] Wedding wedding)
        {
            if (ModelState.IsValid)
            {
                _context.Add(wedding);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(wedding);
        }

        // GET: Weddings/Edit/5
        /// <summary>
        /// Edit a specific event.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Love == null)
            {
                return NotFound();
            }

            var wedding = await _context.Love.FindAsync(id);
            if (wedding == null)
            {
                return NotFound();
            }
            return View(wedding);
        }

        // POST: Weddings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        /// <summary>
        /// Update and save event to database after validation.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="wedding"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Date")] Wedding wedding)
        {
            if (id != wedding.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(wedding);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WeddingExists(wedding.Id))
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
            return View(wedding);
        }

        // GET: Weddings/Delete/5
        /// <summary>
        /// Delete a specific event.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Love == null)
            {
                return NotFound();
            }

            var wedding = await _context.Love
                .FirstOrDefaultAsync(m => m.Id == id);
            if (wedding == null)
            {
                return NotFound();
            }

            return View(wedding);
        }

        // POST: Weddings/Delete/5
        /// <summary>
        /// Update database after event deletion.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Love == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Love'  is null.");
            }
            var wedding = await _context.Love.FindAsync(id);
            if (wedding != null)
            {
                _context.Love.Remove(wedding);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        /// <summary>
        /// Validation if content exists.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private bool WeddingExists(int id)
        {
          return _context.Love.Any(e => e.Id == id);
        }
    }
}