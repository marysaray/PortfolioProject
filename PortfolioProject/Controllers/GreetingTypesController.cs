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
    /// The controller for the greeting type page.
    /// </summary>
    public class GreetingTypesController : Controller
    {
        // field
        private readonly ApplicationDbContext _context;

        // constructor injection: inject services
        public GreetingTypesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: GreetingTypes
        /// <summary>
        /// Displays a view of all greeting types.
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Index()
        {
              return View(await _context.GreetingTypes.ToListAsync());
        }

        // GET: GreetingTypes/Details/5
        /// <summary>
        /// Displays data associated to the specific id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.GreetingTypes == null)
            {
                return NotFound();
            }

            var greetingType = await _context.GreetingTypes
                .FirstOrDefaultAsync(m => m.GreetingId == id);
            if (greetingType == null)
            {
                return NotFound();
            }

            return View(greetingType);
        }

        // GET: GreetingTypes/Create
        /// <summary>
        /// Create a new greeting type.
        /// </summary>
        /// <returns></returns>
        public IActionResult Create()
        {
            return View();
        }

        // POST: GreetingTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        /// <summary>
        /// Add and save to database after validation.
        /// </summary>
        /// <param name="greetingType"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("GreetingId,GreetingName")] GreetingType greetingType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(greetingType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(greetingType);
        }

        // GET: GreetingTypes/Edit/5
        /// <summary>
        /// Edit a specific event.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.GreetingTypes == null)
            {
                return NotFound();
            }

            var greetingType = await _context.GreetingTypes.FindAsync(id);
            if (greetingType == null)
            {
                return NotFound();
            }
            return View(greetingType);
        }

        // POST: GreetingTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        /// <summary>
        /// Update and save greeting type to database after validation.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="greetingType"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("GreetingId,GreetingName")] GreetingType greetingType)
        {
            if (id != greetingType.GreetingId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(greetingType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GreetingTypeExists(greetingType.GreetingId))
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
            return View(greetingType);
        }

        // GET: GreetingTypes/Delete/5
        /// <summary>
        /// Delete a specific greeting type.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.GreetingTypes == null)
            {
                return NotFound();
            }

            var greetingType = await _context.GreetingTypes
                .FirstOrDefaultAsync(m => m.GreetingId == id);
            if (greetingType == null)
            {
                return NotFound();
            }

            return View(greetingType);
        }

        // POST: GreetingTypes/Delete/5
        /// <summary>
        /// Update database after greeting type deletion.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.GreetingTypes == null)
            {
                return Problem("Entity set 'ApplicationDbContext.GreetingTypes'  is null.");
            }
            var greetingType = await _context.GreetingTypes.FindAsync(id);
            if (greetingType != null)
            {
                _context.GreetingTypes.Remove(greetingType);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        /// <summary>
        /// Validation if content exists.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private bool GreetingTypeExists(int id)
        {
          return _context.GreetingTypes.Any(e => e.GreetingId == id);
        }
    }
}
