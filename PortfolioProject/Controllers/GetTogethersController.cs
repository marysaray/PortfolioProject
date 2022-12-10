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
    /// The controller for the get-together page.
    /// </summary>
    public class GetTogethersController : Controller
    {
        // field
        private readonly ApplicationDbContext _context;

        // constructor injection: inject services
        public GetTogethersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: GetTogethers
        /// <summary>
        /// Displays a view of all get-togethers.
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Index()
        {
              return View(await _context.Events.ToListAsync());
        }

        // GET: GetTogethers/Details/5
        /// <summary>
        /// Displays data associated to the specific id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Events == null)
            {
                return NotFound();
            }

            var getTogether = await _context.Events
                .FirstOrDefaultAsync(m => m.Id == id);
            if (getTogether == null)
            {
                return NotFound();
            }

            return View(getTogether);
        }

        // GET: GetTogethers/Create
        /// <summary>
        /// Create a new upload.
        /// </summary>
        /// <returns></returns>
        public IActionResult Create()
        {
            return View();
        }

        // POST: GetTogethers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        /// <summary>
        /// Add and save to database after validation.
        /// </summary>
        /// <param name="getTogether"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Place,Date")] GetTogether getTogether)
        {
            if (ModelState.IsValid)
            {
                _context.Add(getTogether);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(getTogether);
        }

        // GET: GetTogethers/Edit/5
        /// <summary>
        /// Edit a specific event.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Events == null)
            {
                return NotFound();
            }

            var getTogether = await _context.Events.FindAsync(id);
            if (getTogether == null)
            {
                return NotFound();
            }
            return View(getTogether);
        }

        // POST: GetTogethers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        /// <summary>
        /// Update and save event to database after validation.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="getTogether"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Place,Date")] GetTogether getTogether)
        {
            if (id != getTogether.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(getTogether);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GetTogetherExists(getTogether.Id))
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
            return View(getTogether);
        }

        // GET: GetTogethers/Delete/5
        /// <summary>
        /// Delete a specific event.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Events == null)
            {
                return NotFound();
            }

            var getTogether = await _context.Events
                .FirstOrDefaultAsync(m => m.Id == id);
            if (getTogether == null)
            {
                return NotFound();
            }

            return View(getTogether);
        }

        // POST: GetTogethers/Delete/5
        /// <summary>
        /// Update database after event deletion.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Events == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Events'  is null.");
            }
            var getTogether = await _context.Events.FindAsync(id);
            if (getTogether != null)
            {
                _context.Events.Remove(getTogether);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        /// <summary>
        /// Validation if content exists.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private bool GetTogetherExists(int id)
        {
          return _context.Events.Any(e => e.Id == id);
        }
    }
}