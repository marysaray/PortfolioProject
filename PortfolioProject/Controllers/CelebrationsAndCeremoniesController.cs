using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.Differencing;
using Microsoft.EntityFrameworkCore;
using PortfolioProject.Data;
using PortfolioProject.Models;

namespace PortfolioProject.Controllers
{
    /// <summary>
    /// The controller for the celebrations and ceremonies page.
    /// </summary>
    public class CelebrationsAndCeremoniesController : Controller
    {
        // field
        private readonly ApplicationDbContext _context;

        // constructor injection: inject services
        public CelebrationsAndCeremoniesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CelebrationsAndCeremonies
        /// <summary>
        /// Displays a view of all celebrations and ceremonies.
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Index()
        {
              return View(await _context.CelebrationsAndCeremonies.ToListAsync());
        }

        // GET: CelebrationsAndCeremonies/Details/5
        /// <summary>
        /// Displays data associated to the specific id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Create a new upload.
        /// </summary>
        /// <returns></returns>
        public IActionResult Create()
        {
            return View();
        }

        // POST: CelebrationsAndCeremonies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        /// <summary>
        /// Add and save to database after validation.
        /// </summary>
        /// <param name="celebrationsAndCeremonies"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Edit a specific event.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Update and save event to database after validation.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="celebrationsAndCeremonies"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Delete a specific event.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Update database after event deletion.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Validation if content exists.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private bool CelebrationsAndCeremoniesExists(int id)
        {
          return _context.CelebrationsAndCeremonies.Any(e => e.Id == id);
        }
    }
}