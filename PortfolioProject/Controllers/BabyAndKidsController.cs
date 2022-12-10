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
    /// The controller for the baby and kids page.
    /// </summary>
    public class BabyAndKidsController : Controller
    {
        // field
        private readonly ApplicationDbContext _context;

        // constructor injection: inject services
        public BabyAndKidsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: BabyAndKids
        /// <summary>
        /// Displays a view of all babies and kids.
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Index()
        {
              return View(await _context.BabyAndKids.ToListAsync());
        }

        // GET: BabyAndKids/Details/5
        /// <summary>
        /// Displays data associated to the specific id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.BabyAndKids == null)
            {
                return NotFound();
            }

            var babyAndKids = await _context.BabyAndKids
                .FirstOrDefaultAsync(m => m.Id == id);
            if (babyAndKids == null)
            {
                return NotFound();
            }

            return View(babyAndKids);
        }

        // GET: BabyAndKids/Create
        /// <summary>
        /// Create a new upload.
        /// </summary>
        /// <returns></returns>
        public IActionResult Create()
        {
            return View();
        }

        // POST: BabyAndKids/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        /// <summary>
        /// Add and save to database after validation.
        /// </summary>
        /// <param name="babyAndKids"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] BabyAndKids babyAndKids)
        {
            if (ModelState.IsValid)
            {
                _context.Add(babyAndKids);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(babyAndKids);
        }

        // GET: BabyAndKids/Edit/5
        /// <summary>
        /// Edit a specific event.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.BabyAndKids == null)
            {
                return NotFound();
            }

            var babyAndKids = await _context.BabyAndKids.FindAsync(id);
            if (babyAndKids == null)
            {
                return NotFound();
            }
            return View(babyAndKids);
        }

        // POST: BabyAndKids/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        /// <summary>
        /// Update and save event to database after validation.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="babyAndKids"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] BabyAndKids babyAndKids)
        {
            if (id != babyAndKids.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(babyAndKids);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BabyAndKidsExists(babyAndKids.Id))
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
            return View(babyAndKids);
        }

        // GET: BabyAndKids/Delete/5
        /// <summary>
        /// Delete a specific event.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.BabyAndKids == null)
            {
                return NotFound();
            }

            var babyAndKids = await _context.BabyAndKids
                .FirstOrDefaultAsync(m => m.Id == id);
            if (babyAndKids == null)
            {
                return NotFound();
            }

            return View(babyAndKids);
        }

        // POST: BabyAndKids/Delete/5
        /// <summary>
        /// Update database after event deletion.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.BabyAndKids == null)
            {
                return Problem("Entity set 'ApplicationDbContext.BabyAndKids'  is null.");
            }
            var babyAndKids = await _context.BabyAndKids.FindAsync(id);
            if (babyAndKids != null)
            {
                _context.BabyAndKids.Remove(babyAndKids);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        /// <summary>
        /// Validation if content exists.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private bool BabyAndKidsExists(int id)
        {
          return _context.BabyAndKids.Any(e => e.Id == id);
        }
    }
}